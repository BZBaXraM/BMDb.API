export interface ResponseModel<T> {
	data: T;
	message: string;
	isSucceeded: boolean;
	isFailed: boolean;
	statusCode: number;
	errors?: string[];
}
