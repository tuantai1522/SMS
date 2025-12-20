import { createFileRoute } from "@tanstack/react-router";
import { useQuery } from "@tanstack/react-query";

import { env } from "../shared/config/env";
import { apiProbe } from "../shared/api/apiProbe.api";

export const Route = createFileRoute("/")({
  component: HomePage,
});

function HomePage() {
  const probeQuery = useQuery({
    queryKey: ["api", "probe", env.apiBaseUrl, env.apiProbePath],
    queryFn: apiProbe,
    enabled: Boolean(env.apiBaseUrl),
  });

  console.log(env.apiBaseUrl);

  return (
    <div>
      <div>Home (placeholder)</div>

      <h2>API connection</h2>

      {!env.apiBaseUrl ? (
        <div>
          Missing <code>VITE_API_BASE_URL</code>. Set it in{" "}
          <code>.env.local</code>
          (see <code>.env.example</code>).
        </div>
      ) : probeQuery.isLoading ? (
        <div>Checking API…</div>
      ) : probeQuery.isError ? (
        <div>
          API check failed: {String(probeQuery.error)}
          <div>
            Tried: <code>{env.apiBaseUrl}</code>
            <code>{env.apiProbePath}</code>
          </div>
        </div>
      ) : (
        <div>
          API check OK. Swagger title:{" "}
          {probeQuery.data?.info?.title ?? "(unknown)"}
        </div>
      )}
    </div>
  );
}
