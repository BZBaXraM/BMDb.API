import { Routes } from '@angular/router';
import { Movies } from './pages/movies/movies';
import { Search } from './pages/search/search';
import { MovieDetails } from './pages/movie-details/movie-details';
import { Navbar } from './components/navbar/navbar';
import { canActiveAuth } from './guards/access.guard';
import { Login } from './pages/login/login';

export const routes: Routes = [
	{
		path: '',
		component: Navbar,
		runGuardsAndResolvers: 'always',
		children: [
			{ path: 'movies', component: Movies },
			{ path: 'movies/:id', component: MovieDetails },
			{ path: 'search', component: Search },
		],
		canActivate: [canActiveAuth],
	},
	{ path: 'login', component: Login },
];
