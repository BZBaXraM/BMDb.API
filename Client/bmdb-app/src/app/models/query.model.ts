export interface MoviesQuery {
	filterOn?: string;
	filterQuery?: string;
	sortBy?: string;
	isAscending?: boolean;
	pageNumber?: number; // default: 1
	pageSize?: number; // default: 100
	title?: string;
	genre?: string;
	director?: string;
	year?: number;
}
