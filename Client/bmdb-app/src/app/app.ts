import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from './components/navbar/navbar';
import { AuthService } from './services/auth.service';
import { Login } from './pages/login/login';

@Component({
	selector: 'app-root',
	imports: [RouterOutlet, Login],
	templateUrl: './app.html',
	styleUrl: './app.css',
})
export class App {
	authService = inject(AuthService);
}
