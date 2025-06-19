export interface Movie {
	id: string;
	title: string;
	poster: string;
	trailer?: string;
	year: number;
	director: string;
	genres: string[];
	plot?: string;
	imdbId: string;
}
