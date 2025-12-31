import { Link } from "@tanstack/react-router";
import {
  Button,
  Card,
  CardContent,
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
  GoogleIcon,
  Input,
  PasswordInput,
  Separator,
} from "../../shared";
import { useSignIn } from "../hooks/useSignIn";
import Spinner from "../../shared/components/ui/Spinner";

export function SignInForm() {
  const { form, handleSubmit, errorMessage, isPending, googleUrl } =
    useSignIn();

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
                className="relative h-12 w-full justify-center rounded-xl border border-black/15 bg-transparent hover:bg-black/5 dark:border-white/15 dark:hover:bg-white/10 cursor-pointer"
                onClick={() => (window.location.href = googleUrl.data!.url)}
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
                    className="h-12 w-full rounded-xl cursor-pointer"
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
