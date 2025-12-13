import { useMutation } from "@tanstack/react-query";
import type { AxiosError } from "axios";
import type { BaseResult } from "../../../shared/types/baseResult.types";
import { createProject } from "../../apis/createProject.api";
import type { CreateProjectRequest } from "../../types/createProject.types";
import { queryClient } from "../../../shared/lib/queryClient";

export const useCreateProject = () =>
  useMutation<
    BaseResult<string>, // return type
    AxiosError<BaseResult<string>>, // error type
    CreateProjectRequest // variables type
  >({
    mutationFn: createProject, // return BaseResult<string>
    onSuccess: (_, variables) => {
      queryClient.invalidateQueries({
        queryKey: ["projects", variables.workspaceId],
      });
    },
  });
