import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import {
	FormControl,
	FormGroup,
	ReactiveFormsModule,
	Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
	selector: 'app-login',
	imports: [ReactiveFormsModule, CommonModule],
	templateUrl: './login.html',
	styleUrl: './login.css',
})
export class Login {
	private readonly authService = inject(AuthService);
	private readonly router = inject(Router);

	form = new FormGroup({
		accessCode: new FormControl<string | null>(null, Validators.required),
	});

	async onSubmit() {
		if (this.form.invalid) {
			return;
		}

		const accessCode = this.form.value.accessCode;

		if (!accessCode) {
			return;
		}
		this.authService.login({ accessCode }).subscribe({
			next: () => {
				this.router.navigate(['/movies']);
			},
			error: (error) => {
				console.error('Login failed:', error);
				alert('Login failed. Please try again.');
			},
		});
	}
}
