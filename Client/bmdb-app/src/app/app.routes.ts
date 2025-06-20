import { Routes } from '@angular/router';
import { Movies } from './pages/movies/movies';
import { Navbar } from './components/navbar/navbar';
import { Search } from './pages/search/search';
import { MovieDetails } from './pages/movie-details/movie-details';

export const routes: Routes = [
	{ path: '', component: Navbar },
	{ path: 'movies', component: Movies },
	{ path: 'movies/:id', component: MovieDetails },
	{ path: 'search', component: Search },
];
