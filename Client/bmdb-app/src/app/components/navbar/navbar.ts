import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
	selector: 'app-navbar',
	imports: [RouterLink],
	templateUrl: './navbar.html',
	styleUrl: './navbar.css',
})
export class Navbar {
	public auth = inject(AuthService);
	public isLoggedIn = this.auth.isAuth;
	private readonly router = inject(Router);

	public async logout() {
		this.auth.logout();
		await this.router.navigate(['/login']);
	}
}
