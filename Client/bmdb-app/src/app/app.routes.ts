import { Routes } from '@angular/router';
import { Movies } from './pages/movies/movies';
import { Navbar } from './components/navbar/navbar';

export const routes: Routes = [
	{ path: '', component: Navbar },
	{ path: 'movies', component: Movies },
];
