export interface SignInRequest {
  email: string;
  password: string;
}

export interface SignInResponse {
  token: string;
  userId: string;
  email: string;
  nickName: string;
}
