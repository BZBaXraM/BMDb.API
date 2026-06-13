import {
	Component,
	DestroyRef,
	inject,
	input,
	OnInit,
	signal,
} from '@angular/core';
import { MoviesService } from '../../services/movies.service';
import { Movie } from '../../models/movie.model';
import { RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
	selector: 'app-all-movies',
	imports: [RouterLink],
	templateUrl: './all-movies.html',
	styleUrl: './all-movies.css',
})
export class AllMovies implements OnInit {
	movies = input.required<Movie[]>();
	movieService = inject(MoviesService);
	movie = signal<Movie[]>([]);
	query = signal<string>('');
	errors = signal<string[]>([]);
	loading = signal<boolean>(false);
	skeletons = Array.from({ length: 8 });
	private readonly destroyRef = inject(DestroyRef);
	authService = inject(AuthService);

	getMovies() {
		this.loading.set(true);
		this.errors.set([]);
		return this.movieService.getMovies(this.query()).subscribe({
			next: (res) => {
				this.movie.set(res ?? []);
				this.loading.set(false);
			},
			error: (err) => {
				this.errors.set([...this.errors(), err.message]);
				this.loading.set(false);
			},
		});
	}

	getRandomMovie() {
		this.loading.set(true);
		this.errors.set([]);
		return this.movieService.getRandomMovie().subscribe({
			next: (res) => {
				this.movie.set(res ?? []);
				this.loading.set(false);
			},
			error: (err) => {
				this.errors.set([...this.errors(), err.message]);
				this.loading.set(false);
			},
		});
	}

	ngOnInit() {
		if (this.authService.isAuth) {
			const subscription = this.getMovies();
			this.destroyRef.onDestroy(() => {
				subscription.unsubscribe();
			});
		}
	}
}
