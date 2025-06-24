import {
	HttpHandlerFn,
	HttpInterceptorFn,
	HttpRequest,
} from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { catchError, switchMap, throwError } from 'rxjs';

let isRefreshing = false;

export const authTokenInterceptor: HttpInterceptorFn = (req, next) => {
	const auth = inject(AuthService);
	const currentUser = auth.currentUser();

	let token = currentUser?.accessToken || localStorage.getItem('accessToken');

	if (token) {
		req = req.clone({
			setHeaders: {
				Authorization: `Bearer ${token}`,
			},
		});
		console.log(`Adding token to request: ${token}`);
	} else {
		console.warn('No access token found.');
	}

	return next(req).pipe(
		catchError((error) => {
			if (error.status === 401 && !req.url.includes('/auth/')) {
				return refreshAndProceed(auth, req, next);
			}
			return throwError(() => error);
		})
	);
};

const refreshAndProceed = (
	authService: AuthService,
	req: HttpRequest<any>,
	next: HttpHandlerFn
) => {
	if (!isRefreshing) {
		isRefreshing = true;
		return authService.refreshAuthToken().pipe(
			switchMap((res) => {
				isRefreshing = false;
				return next(addToken(req, res.accessToken!));
			}),
			catchError((error) => {
				isRefreshing = false;
				authService.logout();
				return throwError(() => error);
			})
		);
	}

	const token =
		authService.currentUser()?.accessToken ||
		localStorage.getItem('accessToken');
	return next(addToken(req, token!));
};

const addToken = (req: HttpRequest<any>, token: string) => {
	return req.clone({
		setHeaders: {
			Authorization: `Bearer ${token}`,
		},
	});
};
