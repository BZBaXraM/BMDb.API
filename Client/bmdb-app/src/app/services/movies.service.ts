import { environment } from './../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Movie } from '../models/movie.model';
import { ResponseModel } from '../models/response.model';

@Injectable({
	providedIn: 'root',
})
export class MoviesService {
	private readonly http = inject(HttpClient);
	private baseUrl = environment.apiUrl;

	getMovies(query?: string) {
		return this.http
			.get<ResponseModel<Movie[]>>(`${this.baseUrl}movies?${query}`)
			.pipe(map((response) => response.data));
	}

	getMovieById(id: string) {
		return this.http
			.get<ResponseModel<Movie>>(`${this.baseUrl}movies/${id}`)
			.pipe(map((response) => response.data));
	}

	getRandomMovie(limit: number = 10) {
		return this.http
			.get<ResponseModel<Movie[]>>(
				`${this.baseUrl}movies/random?limit=${limit}`
			)
			.pipe(map((response) => response.data));
	}
}
