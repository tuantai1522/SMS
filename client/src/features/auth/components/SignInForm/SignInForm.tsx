import Logo from "../../../shared/components/logo";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "../../../shared/components/ui/Card";
import { Loader } from "lucide-react";

import { Input } from "../../../shared/components/ui/Input";
import { Button } from "../../../shared/components/ui/Button";

import { useSignInForm } from "./SignInForm.hooks";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
} from "../../../shared/components/ui/Form";
import GoogleOauthButton from "../ui/GoogleOauthButton";

const SignInForm = () => {
  const { form, handleSubmit, isLoading } = useSignInForm();

  return (
    <>
      <div className="flex min-h-svh flex-col items-center justify-center gap-6 bg-muted p-6 md:p-10">
        <div className="flex w-full max-w-sm flex-col gap-6">
          <div className="flex items-center gap-2 self-center font-medium">
            <Logo />
            Team Sync.
          </div>
          <div className="flex flex-col gap-6">
            <Card>
              <CardHeader className="text-center">
                <CardTitle className="text-xl">Welcome back</CardTitle>
                <CardDescription>
                  Login with your Email or Google account
                </CardDescription>
              </CardHeader>
              <CardContent>
                <Form {...form}>
                  <form onSubmit={handleSubmit}>
                    <div className="grid gap-6">
                      <div className="flex flex-col gap-4">
                        <GoogleOauthButton label="Login" />
                      </div>
                      <div className="relative text-center text-sm after:absolute after:inset-0 after:top-1/2 after:z-0 after:flex after:items-center after:border-t after:border-border">
                        <span className="relative z-10 bg-background px-2 text-muted-foreground">
                          Or continue with
                        </span>
                      </div>
                      <div className="grid gap-3">
                        <div className="grid gap-2">
                          <FormField
                            control={form.control}
                            name="email"
                            render={({ field }) => (
                              <FormItem>
                                <FormLabel className="dark:text-[#f1f7feb5] text-sm">
                                  Email
                                </FormLabel>
                                <FormControl>
                                  <Input
                                    placeholder="m@example.com"
                                    className="h-12!"
                                    {...field}
                                  />
                                </FormControl>
                              </FormItem>
                            )}
                          />
                        </div>
                        <div className="grid gap-2">
                          <FormField
                            control={form.control}
                            name="password"
                            render={({ field }) => (
                              <FormItem>
                                <div className="flex items-center">
                                  <FormLabel className="dark:text-[#f1f7feb5] text-sm">
                                    Password
                                  </FormLabel>
                                  <a
                                    href="#"
                                    className="ml-auto text-sm underline-offset-4 hover:underline"
                                  >
                                    Forgot your password?
                                  </a>
                                </div>
                                <FormControl>
                                  <Input
                                    type="password"
                                    className="h-12!"
                                    {...field}
                                  />
                                </FormControl>
                              </FormItem>
                            )}
                          />
                        </div>
                        <Button
                          disabled={isLoading}
                          type="submit"
                          className="w-full"
                        >
                          {isLoading && <Loader className="animate-spin" />}
                          Login
                        </Button>
                      </div>
                      <div className="text-center text-sm">
                        Don&apos;t have an account?{" "}
                        {/* <Link
                          to="/sign-up"
                          className="underline underline-offset-4"
                        >
                          Sign up
                        </Link> */}
                        Sign up
                      </div>
                    </div>
                  </form>
                </Form>
              </CardContent>
            </Card>
            <div className="text-balance text-center text-xs text-muted-foreground [&_a]:underline [&_a]:underline-offset-4 [&_a]:hover:text-primary  ">
              By clicking continue, you agree to our{" "}
              <a href="#">Terms of Service</a> and{" "}
              <a href="#">Privacy Policy</a>.
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default SignInForm;
