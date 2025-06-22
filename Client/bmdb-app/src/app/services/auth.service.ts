import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Router } from '@angular/router';
import { AuthResponse } from '../models/auth.model';
import { Login } from '../models/login.model';
import { catchError, map, tap, throwError } from 'rxjs';
import { Token } from '../models/token.model';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	private readonly http = inject(HttpClient);
	private baseUrl = environment.apiUrl;
	public currentUser = signal<AuthResponse | null>(null);
	private readonly router = inject(Router);

	get isAuth() {
		const token = localStorage.getItem('token');
		const refreshToken = localStorage.getItem('refreshToken');
		const accessCode = localStorage.getItem('accessCode');

		if (token && refreshToken && accessCode) {
			return true;
		}
		return false;
	}

	login(payload: Login) {
		return this.http
			.post<AuthResponse>(`${this.baseUrl}auth/login`, payload)
			.pipe(
				map((user) => {
					if (user) this.setCurrentUser(user);
				})
			);
	}

	refreshAuthToken() {
		return this.http
			.post<AuthResponse>(`${this.baseUrl}auth/refresh`, {
				refreshToken: this.currentUser()?.refreshToken,
			})
			.pipe(
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
		const accessCode = localStorage.getItem('accessCode');
		if (token && refreshToken && accessCode) {
			const payload: Partial<Token> = { accessToken: token };

			this.http
				.post(`${this.baseUrl}auth/logout`, payload, {
					headers: {
						Authorization: `Bearer ${token}`,
						'Content-Type': 'application/json',
					},
					responseType: 'text',
				})
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
		localStorage.removeItem('token');
		localStorage.removeItem('refreshToken');
		localStorage.removeItem('accessCode');
		this.router.navigate(['/login']);
	}

	setCurrentUser(token: AuthResponse) {
		localStorage.setItem('token', token.accessToken);
		localStorage.setItem('refreshToken', token.refreshToken);
		localStorage.setItem('accessCode', token.accessCode);
		this.currentUser.set(token);
	}
}
