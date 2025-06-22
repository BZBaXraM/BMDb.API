export interface User {
	id: string;
	email: string;
	accessCode: string;
	refreshTokenDateExpireTime: Date;
	role: string | 'User';
	refreshToken?: string;
}
