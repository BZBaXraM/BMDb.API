import { Component, inject, signal } from '@angular/core';
import { MoviesService } from '../../services/movies.service';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Movie } from '../../models/movie.model';
import { RouterLink } from '@angular/router';
import { Navbar } from '../../components/navbar/navbar';

@Component({
	selector: 'app-search',
	imports: [ReactiveFormsModule, RouterLink, Navbar],
	templateUrl: './search.html',
	styleUrl: './search.css',
})
export class Search {
	private readonly moviesService = inject(MoviesService);
	fb = inject(FormBuilder);
	movies = signal<Movie[]>([]);
	searchSubmitted = false;

	createSearchQuery = (
		title: string,
		year: number | undefined,
		genre: string,
		director: string,
		pageSize: number
	) => {
		const params = new URLSearchParams();

		if (title) {
			params.set('title', title);
		}
		if (year !== undefined) {
			params.set('year', year.toString());
		}
		if (genre) {
			params.set('genre', genre);
		}
		if (director) {
			params.set('director', director);
		}
		if (pageSize) {
			params.set('pageSize', pageSize.toString());
		}

		return params.toString();
	};

	searchForm = this.fb.group({
		title: [''],
		year: [''],
		genre: [''],
		director: [''],
		pageSize: [100],
	});

	onSubmit() {
		this.searchSubmitted = true;
		if (this.searchForm.invalid) {
			return;
		}
		const query = this.createSearchQuery(
			this.searchForm.value.title ?? '',
			this.searchForm.value.year
				? Number(this.searchForm.value.year)
				: undefined,
			this.searchForm.value.genre ?? '',
			this.searchForm.value.director ?? '',
			this.searchForm.value.pageSize
				? Number(this.searchForm.value.pageSize)
				: 100
		);
		if (query) {
			this.moviesService.getMovies(query).subscribe({
				next: (data) => {
					this.movies.set(data);
				},
			});
		}
	}

	clearInputs() {
		this.searchForm.reset();
		this.movies.set([]);
		this.searchSubmitted = false;
	}
}
