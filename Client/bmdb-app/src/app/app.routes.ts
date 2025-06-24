import { Routes } from '@angular/router';
import { Movies } from './pages/movies/movies';
import { Search } from './pages/search/search';
import { MovieDetails } from './pages/movie-details/movie-details';
import { Navbar } from './components/navbar/navbar';
import { Login } from './pages/login/login';
import { accessGuard } from './guards/access-guard';

export const routes: Routes = [
	{
		path: '',
		component: Navbar,
	},
	{
		path: '',
		runGuardsAndResolvers: 'always',
		canActivate: [accessGuard],
		children: [
			{ path: 'movies', component: Movies },
			{ path: 'movies/:id', component: MovieDetails },
			{ path: 'search', component: Search },
		],
	},
	{ path: 'login', component: Login },
];
