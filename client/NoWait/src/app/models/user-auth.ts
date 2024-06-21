export interface UserAuth {
    userId?: number;
    accessToken: string;
    refreshToken: string;
    tokenType: string;
}