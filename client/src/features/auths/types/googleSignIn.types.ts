export interface GoogleSignInRequest {
  code: string;
}

export interface GoogleSignInResponse {
  token: string;
  userId: string;
  email: string;
}
