## Relevant Files

- `frontend/package.json` - Frontend dependencies and scripts for the new React app.
- `frontend/vite.config.ts` - Vite configuration for the new app.
- `frontend/index.html` - Document entry; can be used for early theme bootstrapping if needed.
- `frontend/src/main.tsx` - App bootstrap; compose Router + Query + theme providers.
- `frontend/src/router.tsx` - TanStack Router instance and route registration.
- `frontend/src/routeTree.gen.ts` - Generated route tree (do not edit manually; validate generation workflow).
- `frontend/src/routes/__root.tsx` - Root layout route; host top navigation + theme switcher.
- `frontend/src/routes/index.tsx` - Index/home route; placeholder landing page.
- `frontend/src/shared/lib/queryClient.ts` - Shared TanStack Query client configuration for the new app.
- `frontend/src/shared/lib/http/*` - Shared HTTP client (axios/fetch wrapper) for API calls.
- `frontend/src/shared/theme/*` - Theme types, storage helpers, and document application logic.
- `frontend/src/index.css` - Tailwind base + global CSS variables; theme tokens.
- `frontend/tailwind.config.js` - Dark mode config and token usage.
- `frontend/src/shared/components/ui/*` - Shared UI components that should reflect theming.
- `frontend/src/shared/components/toaster/*` - Toast provider/components; ensure theme compatibility.
- `client/**` - Reference only (optional): source for existing patterns/UI to reuse without continuing to build in the old app.

### Notes

- This task list assumes creating a brand-new React app in a new top-level folder (suggested: `frontend/`).
- The existing `client/` app is treated as reference only; do not implement new features there.
- Prefer adding tests alongside files where possible (e.g., `ThemeProvider.tsx` and `ThemeProvider.test.tsx`).
- If the new app does not have a test framework configured, keep tests minimal and focus on manual verification steps.
- Ensure TanStack Router route tree generation is configured and repeatable (dev + CI).

## Instructions for Completing Tasks

**IMPORTANT:** As you complete each task, check it off in this markdown file by changing `- [ ]` to `- [x]`.

## Tasks

- [x] 0.0 Create feature branch

  - [x] 0.1 Create and checkout a new branch for this feature (e.g., `git checkout -b feature/frontend-setup-and-theming`)

- [x] 1.0 Scaffold a new React app (do not use `client/`)

  - [x] 1.1 Decide and create a new app folder name at repo root (recommended: `frontend/`).
  - [x] 1.2 Scaffold a React + TypeScript app (recommended: Vite) inside the new folder.
  - [x] 1.3 Install and configure core dependencies:
    - TanStack Router (with route tree generation)
    - TanStack Query
    - Tailwind CSS + PostCSS
  - [x] 1.4 Add basic tooling scripts (dev/build/preview/lint) and ensure they run from the new folder.
  - [x] 1.5 Add environment configuration approach for API base URL (keep simple; align with existing `.env` patterns if present).
  - [x] 1.6 Decide whether to reuse UI components from `client/` (copy into `frontend/src/shared/...`) or start minimal equivalents; document the choice.

    Decision: start with minimal shared UI primitives in `frontend/src/shared/components/` to unblock foundation work; selectively copy/reuse pieces from `client/` later only if needed to match the existing design.

- [x] 2.0 Standardize TanStack Router app shell and route structure

  - [x] 2.1 Create router instance (`frontend/src/router.tsx`) and wire it into `frontend/src/main.tsx`.
  - [x] 2.2 Create a root route layout (`frontend/src/routes/__root.tsx`) to host top navigation + providers.
  - [x] 2.3 Create an index route (`frontend/src/routes/index.tsx`) with a simple placeholder home.
  - [x] 2.4 Add placeholder routes for core feature areas (Auth, Projects, Workspaces) with “Coming soon” content.
  - [x] 2.5 Configure and verify route tree generation (`frontend/src/routeTree.gen.ts`): dev workflow and build workflow.
  - [x] 2.6 Confirm route-level loading/error boundaries are handled in a consistent, minimal way.

- [x] 3.0 Standardize TanStack Query configuration and API usage conventions

  - [x] 3.1 Create a single `QueryClient` instance and export it from `frontend/src/shared/lib/queryClient.ts`.
  - [x] 3.2 Set default options: retries, refetch behavior, stale times suitable for a user-facing app.
  - [x] 3.3 Implement a shared HTTP client wrapper in `frontend/src/shared/lib/http/*` (axios or fetch), aligned with how your backend expects auth/errors.
  - [x] 3.4 Define conventions for:
    - Query keys (e.g., per feature: `projectsKeys`, `authKeys`)
    - Query/mutation hooks locations (e.g., `frontend/src/features/<feature>/hooks/queries|mutations`)
  - [x] 3.5 Add guidance for unauthorized/forbidden responses (document expected behavior even if routes are public initially).
  - [x] 3.6 Verify at least one API call works end-to-end in the new app (can be a simple “health” or existing public endpoint).

- [x] 4.0 Implement theming foundation (Light/Dark/System) with persistence

  - [x] 4.1 Define a theme type: `"light" | "dark" | "system"`.
  - [x] 4.2 Implement theme storage helpers for `localStorage` (get/set/remove) with safe defaults.
  - [x] 4.3 Implement theme resolution logic:
    - Saved theme wins
    - If none saved: default to **Light**
    - If `system`: resolve to OS preference via `matchMedia('(prefers-color-scheme: dark)')`
  - [x] 4.4 Implement document application:
    - Toggle `dark` class on root element for Tailwind
    - Set `data-theme` to `light|dark|system`
  - [x] 4.5 Add a listener for OS theme changes and ensure it updates the applied theme when user selected `system`.
  - [x] 4.6 Ensure theme is applied as early as possible on load to minimize FOUC (document-level update before/at first render).
  - [x] 4.7 Add/confirm Tailwind theme tokens/CSS variables in `frontend/src/index.css` (no new design tokens beyond existing primitives).
  - [ ] 4.8 Validate shared UI components render correctly under Light and Dark.

- [x] 5.0 Add top navigation theme switcher UI

  - [x] 5.1 Add a minimal top navigation container in the root layout (`frontend/src/routes/__root.tsx`).
  - [x] 5.2 Implement a theme switcher control with exactly three options: Light, Dark, System.
  - [x] 5.3 Ensure the control reflects the current selection and updates it immediately.
  - [x] 5.4 Ensure the switcher uses shared UI primitives (from `frontend/src/shared/components/ui/*`) and does not introduce new styling tokens.
  - [x] 5.5 Confirm the theme switcher works on all placeholder routes (navigation does not reset theme).

- [x] 6.0 Verify behavior, document conventions, and add minimal tests where appropriate

  - [x] 6.1 Manual verification checklist:
    - Theme defaults to Light on first visit
    - Theme persists after refresh
    - Light/Dark toggle applies immediately
    - System follows OS changes while app is open
  - [ ] 6.2 Add minimal unit tests for theme resolution/application helpers if a test runner is available.
  - [x] 6.3 Add short developer documentation (in this file or a `frontend/README.md`) describing:
    - Where theme logic lives
    - How to add new routes
    - How to create new queries/mutations following conventions
  - [x] 6.4 Run lint/build to ensure no TypeScript errors.

    Note: `6.2` is intentionally left unchecked until a test runner (e.g., Vitest) is added.
