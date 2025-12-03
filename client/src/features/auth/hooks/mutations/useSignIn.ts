import { useMutation } from "@tanstack/react-query";
import { signIn } from "../../apis/signIn.api";
import type { SignInRequest, SignInResponse } from "../../types/signIn.types";
import type { AxiosError } from "axios";
import type { BaseResult } from "../../../shared/types/baseResult.types";

export const useSignIn = () =>
  useMutation<
    BaseResult<SignInResponse>, // return type
    AxiosError<BaseResult<SignInResponse>>, // error type
    SignInRequest // variables type
  >({
    mutationFn: signIn, // return BaseResult<LoginResponse>
  });
