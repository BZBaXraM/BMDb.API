import { environment } from './../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Movie } from '../models/movie.model';

@Injectable({
	providedIn: 'root',
})
export class MoviesService {
	private readonly http = inject(HttpClient);
	private baseUrl = environment.apiUrl;

	getMovies(query?: string) {
		return this.http.get<Movie[]>(`${this.baseUrl}movies?${query}`);
	}

	getMovieById(id: string) {
		return this.http.get<Movie>(`${this.baseUrl}movies/${id}`);
	}

	getRandomMovie(limit: number = 10) {
		return this.http.get<Movie[]>(
			`${this.baseUrl}movies/random?limit=${limit}`
		);
	}
}
