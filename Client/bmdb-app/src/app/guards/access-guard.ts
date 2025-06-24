import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';

export const accessGuard: CanActivateFn = (_route, _state) => {
	const auth = inject(AuthService);
	const router = inject(Router);

	if (auth.isAuth) {
		return true;
	} else {
		router.navigate(['/login']);
		return false;
	}
};
