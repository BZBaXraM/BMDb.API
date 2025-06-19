import { Component, signal } from '@angular/core';
import { Movie } from '../../models/movie.model';
import { Navbar } from '../../components/navbar/navbar';
import { AllMovies } from '../../components/all-movies/all-movies';

@Component({
	selector: 'app-movies',
	imports: [Navbar, AllMovies],
	templateUrl: './movies.html',
	styleUrl: './movies.css',
})
export class Movies {
	movie = signal<Movie[]>([]);
}
