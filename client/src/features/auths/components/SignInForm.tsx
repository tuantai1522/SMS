import {
  Button,
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
  GoogleIconButton,
  Input,
  Link,
  PasswordInput,
  Separator,
  Spinner,
} from "../../shared";
import { useSignIn } from "../hooks/useSignIn";

export function SignInForm() {
  const { form, handleSubmit, errorMessage, isPending, googleUrl, navigate } =
    useSignIn();

  return (
    <div className="min-h-[calc(100vh-56px)] px-4 py-12">
      <div className="mx-auto flex w-full max-w-sm flex-col items-center justify-center gap-8">
        <header className="text-center">
          <h1 className="text-2xl font-semibold tracking-tight">
            Welcome back
          </h1>
        </header>

        <div className="grid w-full gap-6">
          <div className="grid w-full gap-3">
            <GoogleIconButton
              onHandle={() => (window.location.href = googleUrl.data!.url)}
            />
          </div>

          <Separator className="my-4" />

          <Form {...form}>
            <form className="grid w-full gap-5" onSubmit={handleSubmit}>
              <FormField
                control={form.control}
                name="email"
                render={({ field }) => (
                  <FormItem>
                    <div className="flex items-center justify-between">
                      <FormLabel className="text-sm">Email</FormLabel>
                    </div>
                    <FormControl>
                      <Input
                        placeholder=""
                        autoComplete="email"
                        className="h-12 w-full rounded-xl"
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
                    <div className="flex items-center justify-between">
                      <FormLabel className="text-sm">Password</FormLabel>
                      <Link
                        variant="primary"
                        onClick={() => navigate({ to: "/forgot-password" })}
                      >
                        Forgot password
                      </Link>
                    </div>
                    <FormControl>
                      <PasswordInput
                        placeholder=""
                        autoComplete="current-password"
                        className="h-12 w-full rounded-xl"
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
                variant="neutral"
                type="submit"
                className="h-12 w-full rounded-xl"
              >
                {isPending ? <Spinner /> : "Sign in"}
              </Button>

              <div className="text-center text-sm">
                Don&apos;t have an account?{" "}
                <Link
                  variant="primary"
                  onClick={() => navigate({ to: "/forgot-password" })}
                >
                  Sign up
                </Link>
              </div>
            </form>
          </Form>
        </div>
      </div>
    </div>
  );
}
