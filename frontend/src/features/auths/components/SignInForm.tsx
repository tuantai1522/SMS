import { Link, useNavigate, useRouter } from "@tanstack/react-router";
import { Button } from "../../shared/components/ui/Button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "../../shared/components/ui/Card";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "../../shared/components/ui/Form";
import { Input, Separator } from "../../shared/components/ui";
import { GoogleIcon } from "../../shared/components/icons/GoogleIcon";
import { z } from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { useAuthStore } from "../stores/auth.store";
import { useMutation } from "@tanstack/react-query";
import { signIn } from "../apis/signIn.api";

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

  const { mutate, isPending } = useMutation({
    mutationFn: signIn,
    onSuccess: async (res) => {
      if (res.success && res.data) {
        setToken(res.data.token);

        router.invalidate();

        navigate({ to: "/", replace: true });
        return;
      }

      const message = res?.errors?.map((e: any) => e.description).join(", ");
      console.error("Sign-in failed:", message);
    },
  });

  const handleSubmit = form.handleSubmit((payload) => mutate(payload));

  return (
    <>
      <div className="min-h-[calc(100vh-56px)] bg-white px-4 py-10 dark:bg-black">
        <div className="mx-auto w-full max-w-5xl">
          <div className="grid gap-8 lg:grid-cols-2 lg:items-stretch">
            <section className="hidden lg:block">
              <div className="relative h-full overflow-hidden rounded-2xl border border-black/10 bg-linear-to-br from-black/5 via-transparent to-black/10 p-8 dark:border-white/10 dark:bg-white/5 dark:from-white/10 dark:via-white/5 dark:to-white/15">
                <div className="flex h-full flex-col justify-between gap-8">
                  <div>
                    <div className="text-sm font-medium text-black/70 dark:text-white/80">
                      Nexa
                    </div>
                    <h1 className="mt-3 text-3xl font-semibold leading-tight text-black dark:text-white">
                      Welcome back
                    </h1>
                    <p className="mt-2 max-w-md text-base text-black/70 dark:text-white/75">
                      Sign in to continue and manage your workspaces and
                      projects.
                    </p>
                  </div>

                  <ul className="grid gap-3 text-sm text-black/70 dark:text-white/80">
                    <li className="flex items-start gap-3">
                      <span className="mt-1 inline-block h-2 w-2 rounded-full bg-black/40 dark:bg-white/60" />
                      Clean, fast UI with theme support
                    </li>
                    <li className="flex items-start gap-3">
                      <span className="mt-1 inline-block h-2 w-2 rounded-full bg-black/40 dark:bg-white/60" />
                      Built with modern React + TanStack Router
                    </li>
                    <li className="flex items-start gap-3">
                      <span className="mt-1 inline-block h-2 w-2 rounded-full bg-black/40 dark:bg-white/60" />
                      Ready to connect to auth APIs later
                    </li>
                  </ul>

                  <div className="text-xs text-black/50 dark:text-white/50">
                    UI-only preview. Authentication is not wired yet.
                  </div>
                </div>

                <div
                  aria-hidden
                  className="pointer-events-none absolute -right-24 -top-24 h-64 w-64 rounded-full bg-black/5 blur-3xl dark:bg-white/10"
                />
              </div>
            </section>

            <section className="flex items-center justify-center">
              <Card className="w-full max-w-md">
                <CardHeader>
                  <CardTitle>Sign in</CardTitle>
                  <CardDescription>Sign in to continue</CardDescription>
                </CardHeader>

                <CardContent>
                  <div className="grid gap-4">
                    <Button
                      variant="secondary"
                      className="w-full"
                      onClick={() => {
                        /* no-op (UI only) */
                      }}
                    >
                      <GoogleIcon className="text-black/80 dark:text-white/80" />
                      Login with Google
                    </Button>

                    <div className="relative">
                      <div className="absolute inset-0 flex items-center">
                        <Separator />
                      </div>
                      <div className="relative flex justify-center">
                        <span className="bg-white/80 px-2 text-xs text-black/60 dark:bg-black/60 dark:text-white/60">
                          or continue with
                        </span>
                      </div>
                    </div>

                    <Form {...form}>
                      <form className="grid gap-4" onSubmit={handleSubmit}>
                        <div className="grid gap-1.5">
                          <FormField
                            control={form.control}
                            name="email"
                            render={({ field }) => (
                              <FormItem>
                                <FormLabel>Email</FormLabel>
                                <FormControl>
                                  <Input
                                    placeholder="m@example.com"
                                    className="h-12!"
                                    {...field}
                                  />
                                </FormControl>
                                <FormMessage />
                              </FormItem>
                            )}
                          />
                        </div>

                        <div className="grid gap-1.5">
                          <FormField
                            control={form.control}
                            name="password"
                            render={({ field }) => (
                              <FormItem>
                                <FormLabel>Password</FormLabel>
                                <FormControl>
                                  <Input
                                    placeholder="••••••••••"
                                    autoComplete="current-password"
                                    {...field}
                                    type="password"
                                  />
                                </FormControl>
                                <FormMessage />
                              </FormItem>
                            )}
                          />
                        </div>

                        <div className="flex items-center justify-between gap-4">
                          {/* <Checkbox
                          label="Remember me"
                          {...rememberMeProps}
                          ref={rememberMeRef}
                        /> */}
                          <Link
                            className="text-sm text-black/70 underline-offset-4 hover:underline dark:text-white/70"
                            to="/forgot-password"
                          >
                            Forgot password?
                          </Link>
                        </div>

                        <Button
                          className="w-full"
                          type="submit"
                          disabled={isPending}
                        >
                          Sign in
                        </Button>

                        <div className="text-center text-sm text-black/60 dark:text-white/60">
                          Don’t have an account?{" "}
                          <a
                            className="font-medium text-black underline-offset-4 hover:underline dark:text-white"
                            href="/sign-up"
                          >
                            Create account
                          </a>
                        </div>
                      </form>
                    </Form>
                  </div>
                </CardContent>
              </Card>
            </section>
          </div>
        </div>
      </div>
    </>
  );
}
