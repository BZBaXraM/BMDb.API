import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Router } from '@angular/router';
import { catchError, map, tap, throwError } from 'rxjs';
import { Token } from '../models/token.model';
import { LoginModel } from '../models/login.model';
import { AuthResponse } from '../models/auth.model';
import { ResponseModel } from '../models/response.model';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	private readonly http = inject(HttpClient);
	private baseUrl = environment.apiUrl;
	public currentUser = signal<AuthResponse | null>(null);
	private readonly router = inject(Router);

	constructor() {
		this.initializeFromStorage();
	}

	private initializeFromStorage() {
		const accessToken = localStorage.getItem('accessToken');
		const refreshToken = localStorage.getItem('refreshToken');
		const refreshTokenExpireTime = localStorage.getItem(
			'refreshTokenExpireTime'
		);

		if (accessToken && refreshToken && refreshTokenExpireTime) {
			const expireTime = new Date(refreshTokenExpireTime);
			if (expireTime > new Date()) {
				this.currentUser.set({
					accessToken,
					refreshToken,
					refreshTokenExpireTime: expireTime,
				});
			} else {
				this.clearLocalSession();
			}
		}
	}

	get isAuth() {
		const token = localStorage.getItem('accessToken');
		const refreshToken = localStorage.getItem('refreshToken');
		const refreshTokenExpireTime = localStorage.getItem(
			'refreshTokenExpireTime'
		);

		if (token && refreshToken && refreshTokenExpireTime) {
			const expireTime = new Date(refreshTokenExpireTime);
			if (expireTime > new Date()) {
				return true;
			}
		}
		return false;
	}

	login(payload: LoginModel) {
		return this.http
			.post<ResponseModel<AuthResponse>>(
				`${this.baseUrl}auth/login`,
				payload
			)
			.pipe(
				map((response) => response.data),
				tap((user) => {
					if (user) {
						this.setCurrentUser(user);
						console.log(user);
					}
				}),
				catchError((error) => {
					console.error('Login error:', error);
					return throwError(() => new Error('Login failed'));
				})
			);
	}

	refreshAuthToken() {
		const refreshToken = localStorage.getItem('refreshToken');
		return this.http
			.post<ResponseModel<AuthResponse>>(
				`${this.baseUrl}auth/refresh-token`,
				{
					refreshToken: refreshToken,
				}
			)
			.pipe(
				map((response) => response.data),
				tap((user) => {
					if (user) this.setCurrentUser(user);
				}),
				catchError((error) => {
					console.error('Error refreshing token:', error);
					this.logout();
					return throwError(
						() => new Error('Failed to refresh token')
					);
				})
			);
	}

	logout() {
		const token = localStorage.getItem('accessToken');
		const refreshToken = localStorage.getItem('refreshToken');
		if (token && refreshToken) {
			const payload: Partial<Token> = { accessToken: token };

			this.http
				.post<ResponseModel<unknown>>(
					`${this.baseUrl}auth/logout`,
					payload,
					{
						headers: {
							Authorization: `Bearer ${token}`,
							'Content-Type': 'application/json',
						},
					}
				)
				.subscribe({
					next: () => {
						this.clearLocalSession();
					},
					error: (error) => {
						console.error('Error during logout:', error);
						this.clearLocalSession();
					},
				});
		} else {
			this.clearLocalSession();
		}
	}

	clearLocalSession() {
		localStorage.removeItem('accessToken');
		localStorage.removeItem('refreshToken');
		localStorage.removeItem('refreshTokenExpireTime');
		this.currentUser.set(null);
		this.router.navigate(['/login']);
	}

	setCurrentUser(token: AuthResponse) {
		let expireTime: string;

		if (token.refreshTokenExpireTime) {
			expireTime =
				typeof token.refreshTokenExpireTime === 'string'
					? token.refreshTokenExpireTime
					: token.refreshTokenExpireTime.toISOString();
		} else {
			expireTime = new Date(
				Date.now() + 24 * 60 * 60 * 1000
			).toISOString();
		}

		localStorage.setItem('accessToken', token.accessToken!);
		localStorage.setItem('refreshToken', token.refreshToken!);
		localStorage.setItem('refreshTokenExpireTime', expireTime);

		this.currentUser.set({
			accessToken: token.accessToken,
			refreshToken: token.refreshToken,
			refreshTokenExpireTime: new Date(expireTime),
		});
	}
}
