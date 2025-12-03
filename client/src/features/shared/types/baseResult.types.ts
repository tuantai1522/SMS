export type BaseResult<T> = {
  success: boolean;
  data?: T;
  errors?: Error[];
};

type Error = {
  code: string;
  description: string;
  type: number;
};
