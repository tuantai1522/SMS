export type SignInRequest = {
  email: string;
  password: string;
};

export type SignInResponse = {
  token: string;
  userId: string;
  email: string;
  nickName: string;
};
