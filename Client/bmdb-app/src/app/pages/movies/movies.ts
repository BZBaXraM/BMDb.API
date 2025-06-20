import { Component, inject, signal } from '@angular/core';
import { Movie } from '../../models/movie.model';
import { AllMovies } from '../../components/all-movies/all-movies';
import { MoviesService } from '../../services/movies.service';

@Component({
	selector: 'app-movies',
	imports: [AllMovies],
	templateUrl: './movies.html',
	styleUrl: './movies.css',
})
export class Movies {
	movie = signal<Movie[]>([]);
	private readonly moviesService = inject(MoviesService);

	getRandomMovie() {
		return this.moviesService
			.getRandomMovie()
			.subscribe((res) => this.movie.set(res));
	}
}
