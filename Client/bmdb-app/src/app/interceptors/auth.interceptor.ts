import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';

export const authTokenInterceptor: HttpInterceptorFn = (req, next) => {
	const auth = inject(AuthService);
	const currentUser = auth.currentUser();

	if (currentUser) {
		const token = currentUser.accessToken;
		if (token) {
			req = req.clone({
				setHeaders: {
					Authorization: `Bearer ${token}`,
				},
			});
		}
	}

	return next(req);
};
