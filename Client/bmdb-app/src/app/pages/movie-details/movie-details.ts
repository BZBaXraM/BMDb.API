import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { MoviesService } from '../../services/movies.service';
import { Movie } from '../../models/movie.model';

@Component({
	selector: 'app-movie-details',
	imports: [],
	templateUrl: './movie-details.html',
	styleUrl: './movie-details.css',
})
export class MovieDetails implements OnInit {
	private readonly movieService = inject(MoviesService);
	movie = signal<Movie | null>(null);
	loading = signal<boolean>(false);
	errors = signal<string[]>([]);
	private readonly destroyRef = inject(DestroyRef);

	getMovieById(id: string) {
		return this.movieService.getMovieById(id).subscribe({
			next: (res) => {
				this.movie.set(res);
				this.loading.set(true);
			},
			error: (err) => {
				this.errors.set([...this.errors(), err.message]);
				this.loading.set(false);
				console.log(err);
			},
		});
	}

	ngOnInit(): void {
		const movieId =
			this.movie()?.id ?? location.pathname.split('/').pop() ?? '';
		const subscription = this.getMovieById(movieId);

		this.destroyRef.onDestroy(() => {
			subscription.unsubscribe();
		});
	}
}
