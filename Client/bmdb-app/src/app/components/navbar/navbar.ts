import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { ThemeToggle } from '../theme-toggle/theme-toggle';

@Component({
	selector: 'app-navbar',
	imports: [RouterLink, ThemeToggle],
	templateUrl: './navbar.html',
	styleUrl: './navbar.css',
})
export class Navbar {
	public auth = inject(AuthService);
	private readonly router = inject(Router);

	mobileMenuOpen = false;

	toggleMobileMenu() {
		this.mobileMenuOpen = !this.mobileMenuOpen;
	}

	closeMobileMenu() {
		this.mobileMenuOpen = false;
	}

	public async logout() {
		this.auth.logout();
		this.closeMobileMenu();
		await this.router.navigate(['/login']);
	}
}
