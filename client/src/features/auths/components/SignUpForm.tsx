import {
  Button,
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
  Input,
  Link,
  PasswordInput,
  Separator,
  Spinner,
} from "../../shared";
import { useSignUp } from "../hooks/useSignUp";
import { GoogleButton } from "./GoogleButton";

export function SignUpForm() {
  const { form, handleSubmit, errorMessage, isPending, navigate } = useSignUp();
  return (
    <div className="min-h-[calc(100vh-56px)] px-4 py-12">
      <div className="mx-auto flex w-full max-w-sm flex-col items-center justify-center gap-8">
        <header className="text-center">
          <h1 className="text-2xl font-semibold tracking-tight">
            Create an account
          </h1>
        </header>

        <div className="grid w-full gap-6">
          <div className="grid w-full gap-3">
            <GoogleButton titlte="Sign up with Google" />
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
                {isPending ? <Spinner /> : "Sign up"}
              </Button>

              <div className="text-center text-sm">
                Already registered{" "}
                <Link
                  variant="primary"
                  onClick={() => navigate({ to: "/sign-in" })}
                >
                  Sign in
                </Link>
              </div>
            </form>
          </Form>
        </div>
      </div>
    </div>
  );
}
