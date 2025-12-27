import { Link, useNavigate, useRouter } from "@tanstack/react-router";
import { Button } from "../../shared/components/ui/Button";
import { Card, CardContent } from "../../shared/components/ui/Card";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "../../shared/components/ui/Form";
import { Input, PasswordInput, Separator } from "../../shared/components/ui";
import { GoogleIcon } from "../../shared/components/icons/GoogleIcon";
import { z } from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { useAuthStore } from "../stores/auth.store";
import { useMutation } from "@tanstack/react-query";
import { signIn } from "../apis/signIn.api";
import type { ApiError } from "../../shared/types/baseResult";
import { useState } from "react";
import Spinner from "../../shared/components/ui/Spinner";

const signInSchema = z.object({
  email: z.email("Enter a valid email address.").min(1, "Email is required."),
  password: z.string().min(1, "Password is required."),
  rememberMe: z.boolean().optional(),
});

type SignInFormValues = z.infer<typeof signInSchema>;

export function SignInForm() {
  const form = useForm<SignInFormValues>({
    resolver: zodResolver(signInSchema),
    defaultValues: {
      email: "",
      password: "",
      rememberMe: false,
    },
    mode: "onTouched",
  });

  const router = useRouter();
  const navigate = useNavigate();
  const setToken = useAuthStore((s) => s.setAccessToken);

  const [errorMessage, setErrorMessage] = useState<string | undefined>(
    undefined
  );

  const { mutate, isPending } = useMutation({
    mutationFn: signIn,
    onSuccess: async (res) => {
      if (res.success && res.data) {
        setToken(res.data.token);

        router.invalidate();

        navigate({ to: "/", replace: true });
        return;
      }

      const message = res?.errors
        ?.map((err: ApiError) => err.description)
        .join(", ");

      setErrorMessage(message);
    },
  });

  const handleSubmit = form.handleSubmit((payload) => mutate(payload));

  return (
    <div className="min-h-[calc(100vh-56px)] bg-white px-4 py-12 dark:bg-black">
      <div className="mx-auto flex w-full max-w-md flex-col items-center justify-center gap-8">
        <header className="text-center">
          <h1 className="text-2xl font-semibold tracking-tight text-black dark:text-white">
            Welcome back
          </h1>
        </header>

        <Card className="w-full px-6 py-7">
          <CardContent>
            <div className="grid gap-6">
              <Button
                variant="ghost"
                className="relative h-12 w-full justify-center rounded-xl border border-black/15 bg-transparent hover:bg-black/5 dark:border-white/15 dark:hover:bg-white/10"
                onClick={() => {}}
              >
                <span className="absolute left-4 inline-flex items-center">
                  <GoogleIcon className="text-black/80 dark:text-white/80" />
                </span>
                <span className="text-sm font-medium text-black dark:text-white">
                  Sign in with Google
                </span>
              </Button>

              <Separator className="my-2" />

              <Form {...form}>
                <form className="grid gap-5" onSubmit={handleSubmit}>
                  <FormField
                    control={form.control}
                    name="email"
                    render={({ field }) => (
                      <FormItem>
                        <FormLabel className="text-sm">Email</FormLabel>
                        <FormControl>
                          <Input
                            placeholder=""
                            autoComplete="email"
                            className="h-12 rounded-xl"
                            {...field}
                          />
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />

                  <FormField
                    control={form.control}
                    name="password"
                    render={({ field }) => (
                      <FormItem>
                        <div className="flex items-center justify-between gap-4">
                          <FormLabel className="text-sm">Password</FormLabel>
                          <Link
                            className="text-sm text-black/60 underline-offset-4 hover:underline dark:text-white/60"
                            to="/forgot-password"
                          >
                            Forgot your password?
                          </Link>
                        </div>
                        <FormControl>
                          <PasswordInput
                            placeholder=""
                            autoComplete="current-password"
                            className="h-12 rounded-xl"
                            {...field}
                          />
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />
                  {errorMessage ? (
                    <p className="text-center text-sm font-medium text-red-600 dark:text-red-500">
                      {errorMessage}
                    </p>
                  ) : null}
                  <Button
                    variant="muted"
                    className="h-12 w-full rounded-xl"
                    type="submit"
                    disabled={isPending}
                  >
                    {isPending ? <Spinner /> : "Sign In"}
                  </Button>

                  <div className="text-center text-sm text-black/60 dark:text-white/60">
                    Don&apos;t have an account?{" "}
                    <Link
                      className="font-medium text-black underline-offset-4 hover:underline dark:text-white"
                      to="/sign-up"
                    >
                      Sign up
                    </Link>
                  </div>
                </form>
              </Form>
            </div>
          </CardContent>
        </Card>
      </div>
    </div>
  );
}
