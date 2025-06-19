import { Component, inject, input, signal } from '@angular/core';
import { MoviesQuery } from '../../models/query.model';
import { MoviesService } from '../../services/movies.service';
import { Movie } from '../../models/movie.model';
import { RouterLink } from '@angular/router';

@Component({
	selector: 'app-all-movies',
	imports: [RouterLink],
	templateUrl: './all-movies.html',
	styleUrl: './all-movies.css',
})
export class AllMovies {
	movies = input.required<Movie[]>();
	movieService = inject(MoviesService);
	movie = signal<Movie[]>([]);
	query = signal<MoviesQuery>({} as MoviesQuery);

	getMovies() {
		return this.movieService.getMovies(this.query()).subscribe((res) => {
			this.movie.set(res);
			console.log(res);
		});
	}

	getRandomMovie() {
		return this.movieService.getRandomMovie().subscribe((res) => {
			this.movie.set(res);
		});
	}

	ngOnInit() {
		this.getMovies();
	}
}
