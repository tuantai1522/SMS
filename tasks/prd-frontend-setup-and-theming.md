# PRD: Frontend Setup and Theming Foundation

## 1. Introduction / Overview

We need to set up the Frontend foundation for a project task management product using React with TanStack Router and TanStack Query. The primary goal is a maintainable, reusable app architecture that can support multiple feature modules and existing backend APIs.

In addition, the app must support user-selectable themes (Light/Dark/System). Theme preference is stored locally in the browser (localStorage) and applied consistently across the application UI.

## 2. Goals

1. Establish a clear Frontend architecture that supports feature modules (Auth, Projects, Users, Workspaces, Shared).
2. Ensure routing is in place using TanStack Router with a predictable route organization.
3. Ensure server communication and caching are handled via TanStack Query with shared configuration.
4. Implement a theme system supporting **Light**, **Dark**, and **System** themes.
5. Persist theme preference in **localStorage**, and apply it on app load.

## 3. User Stories

1. As a user, I can navigate between pages (even if mostly placeholder pages initially) without full page reloads.
2. As a user, when data is fetched from APIs, I get consistent loading and error behavior.
3. As a user, I can switch between Light and Dark theme.
4. As a user, I can set theme to System and have the app follow my OS theme.
5. As a user, when I refresh the page, my selected theme remains applied.

## 4. Functional Requirements

### 4.1 App Architecture

1. The system must organize code by feature modules (e.g., `src/features/...`) and a shared layer for reusable primitives.
2. The system must define a single app entry point that composes:
   - Router provider (TanStack Router)
   - Query client provider (TanStack Query)
   - Global UI providers already used in the codebase (e.g., toaster/dialog providers if present)
3. The system must provide a single shared HTTP client approach consistent with the existing codebase (e.g., axios wrapper under shared lib), without duplicating API client patterns.
4. The system must provide shared error handling conventions for API errors (minimum: consistent user-visible toast or error boundary behavior).

### 4.2 Routing (TanStack Router)

1. The system must use TanStack Router as the routing solution.
2. The system must support a basic public route structure initially (no auth gating required yet).
3. The system must define at minimum:
   - A root route layout
   - An index/home route
   - Placeholder routes for at least the main feature areas (e.g., Auth, Projects, Workspaces), even if they only display “Coming soon” content.
4. The system must keep routing definitions consistent with TanStack Router best practices (route tree generation where applicable).

### 4.3 Data Fetching / Caching (TanStack Query)

1. The system must configure a shared `QueryClient` with sensible defaults:
   - Retry behavior appropriate for user-facing apps
   - Global handling for unauthorized/forbidden responses if encountered (even if routes are public for now)
2. The system must provide a consistent way for feature modules to define:
   - Query keys
   - Query functions
   - Mutation functions
3. The system must expose a standard pattern for:
   - Loading states
   - Error states
   - Empty states

### 4.4 Theming (Light / Dark / System)

1. The system must support three theme modes:
   1. Light
   2. Dark
   3. System (follows OS preference)
2. The system must store the user’s theme selection in `localStorage`.
3. On first visit (when there is no saved preference), the system must default to **Light** theme.
4. The system must apply the theme on initial app load before or at first render to avoid visible “flash” (FOUC) as much as reasonably possible.
5. The system must update the app’s theme immediately when the user changes it.
6. When set to System theme, the system must react to OS theme changes (e.g., if the OS switches from Light to Dark while the app is open).
7. The system must integrate with Tailwind and the existing shared UI components (`src/features/shared/components/ui/`) so the theme affects all components consistently.
8. The system must apply theme state at the document level by:
   - Toggling the `dark` class on the root element to enable Tailwind `dark:` variants.
   - Setting a `data-theme` attribute (e.g., `data-theme="light" | "dark" | "system"`) to support component styling and future extension.

### 4.5 Theme Switcher UI

1. The system must provide a theme switcher UI control in the **top navigation**.
2. The control must allow choosing exactly: Light, Dark, System.
3. The control must reflect the currently selected theme.

## 5. Non-Goals (Out of Scope)

1. No server-side persistence or user-profile storage of theme preferences.
2. No role-based access control or protected routes (routes remain public initially).
3. No requirement to implement complete task management screens (boards, lists, etc.) as part of this setup.
4. No requirement to introduce a new design system or new colors outside the existing Tailwind/theme primitives.

## 6. Design Considerations

- The solution must use Tailwind theming patterns and remain compatible with existing shared UI components.
- The theme implementation should rely on standard Tailwind approaches (e.g., class-based dark mode with CSS variables where the UI kit expects them).
- The theme switcher should be placed in the top navigation and remain minimal and non-intrusive.

## 7. Technical Considerations

- Existing code indicates usage of:
  - TanStack Router route tree generation (`routeTree.gen.ts`)
  - Shared query client (`src/features/shared/lib/queryClient.ts`)
  - Tailwind (`tailwind.config.js`, `index.css`)
  - Shared UI components under `src/features/shared/components/ui/`
- Prefer extending existing utilities and patterns rather than creating parallel systems.
- Theme selection should be represented as a small, typed state (e.g., `"light" | "dark" | "system"`).
- Ensure SSR is not assumed (this is a Vite SPA). Theme initialization should still avoid flicker (e.g., setting document class early).

## 8. Success Metrics

1. Developer can add a new route and feature page following a documented pattern with minimal confusion.
2. Developer can add a new query/mutation using the shared QueryClient and conventions.
3. Theme switching works across the app:
   - Light ↔ Dark changes apply immediately
   - System follows OS and reacts to OS changes
   - Theme persists after refresh
4. No regressions in existing shared UI components appearance when switching themes.

## 9. Open Questions

All previously open questions are resolved:

1. Theme switcher location: **Top navigation**.
2. Theme application strategy: use both document-level `dark` class and `data-theme` attribute.
3. Default theme: **Light** on first visit.
