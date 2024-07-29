/* eslint-disable */
/* prettier-ignore */
// Generated by elegant-router
// Read more: https://github.com/soybeanjs/elegant-router

import type { RouteComponent } from "vue-router";
import type { LastLevelRouteKey, RouteLayout } from "@elegant-router/types";

import BaseLayout from "@/layouts/base-layout/index.vue";
import BlankLayout from "@/layouts/blank-layout/index.vue";

export const layouts: Record<RouteLayout, RouteComponent | (() => Promise<RouteComponent>)> = {
  base: BaseLayout,
  blank: BlankLayout,
};

export const views: Record<LastLevelRouteKey, RouteComponent | (() => Promise<RouteComponent>)> = {
  gj10_gj1010: () => import("@/views/GJ10/GJ1010/index.vue"),
  gj10_gj1030: () => import("@/views/GJ10/GJ1030/index.vue"),
  gj80_gj8090: () => import("@/views/GJ80/GJ8090/index.vue"),
  403: () => import("@/views/_builtin/403/index.vue"),
  404: () => import("@/views/_builtin/404/index.vue"),
  500: () => import("@/views/_builtin/500/index.vue"),
  "iframe-page": () => import("@/views/_builtin/iframe-page/[url].vue"),
  login: () => import("@/views/_builtin/login/index.vue"),
  todo: () => import("@/views/_builtin/todo/index.vue"),
  home: () => import("@/views/home/index.vue"),
  "user-center": () => import("@/views/user-center/index.vue"),
};
