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
  gj10_gj1020: () => import("@/views/GJ10/GJ1020/index.vue"),
  gj10_gj1030: () => import("@/views/GJ10/GJ1030/index.vue"),
  gj10_gj1040: () => import("@/views/GJ10/GJ1040/index.vue"),
  gj10_gj1050: () => import("@/views/GJ10/GJ1050/index.vue"),
  gj10_gj1060: () => import("@/views/GJ10/GJ1060/index.vue"),
  gj10_gj1070: () => import("@/views/GJ10/GJ1070/index.vue"),
  gj1031: () => import("@/views/GJ1031/index.vue"),
  gj20_gj2010: () => import("@/views/GJ20/GJ2010/index.vue"),
  gj20_gj2020: () => import("@/views/GJ20/GJ2020/index.vue"),
  gj20_gj2030: () => import("@/views/GJ20/GJ2030/index.vue"),
  gj20_gj2040: () => import("@/views/GJ20/GJ2040/index.vue"),
  gj20_gj2050: () => import("@/views/GJ20/GJ2050/index.vue"),
  gj20_gj2060: () => import("@/views/GJ20/GJ2060/index.vue"),
  gj20_gj2070: () => import("@/views/GJ20/GJ2070/index.vue"),
  gj20_gj2080: () => import("@/views/GJ20/GJ2080/index.vue"),
  gj20_gj2090: () => import("@/views/GJ20/GJ2090/index.vue"),
  gj20_gj2100: () => import("@/views/GJ20/GJ2100/index.vue"),
  gj20_gj2110: () => import("@/views/GJ20/GJ2110/index.vue"),
  gj20_gj2120: () => import("@/views/GJ20/GJ2120/index.vue"),
  gj30_gj3010: () => import("@/views/GJ30/GJ3010/index.vue"),
  gj30_gj3020: () => import("@/views/GJ30/GJ3020/index.vue"),
  gj30_gj3030: () => import("@/views/GJ30/GJ3030/index.vue"),
  gj40_gj4010: () => import("@/views/GJ40/GJ4010/index.vue"),
  gj40_gj4020: () => import("@/views/GJ40/GJ4020/index.vue"),
  gj40_gj4030: () => import("@/views/GJ40/GJ4030/index.vue"),
  gj40_gj4040: () => import("@/views/GJ40/GJ4040/index.vue"),
  gj40_gj4050: () => import("@/views/GJ40/GJ4050/index.vue"),
  gj40_gj4060: () => import("@/views/GJ40/GJ4060/index.vue"),
  gj40_gj4070: () => import("@/views/GJ40/GJ4070/index.vue"),
  gj50_gj5010: () => import("@/views/GJ50/GJ5010/index.vue"),
  gj60_gj6010: () => import("@/views/GJ60/GJ6010/index.vue"),
  gj60_gj6020: () => import("@/views/GJ60/GJ6020/index.vue"),
  gj60_gj6021: () => import("@/views/GJ60/GJ6021/index.vue"),
  gj60_gj6030: () => import("@/views/GJ60/GJ6030/index.vue"),
  gj60_gj6040: () => import("@/views/GJ60/GJ6040/index.vue"),
  gj70_gj7010: () => import("@/views/GJ70/GJ7010/index.vue"),
  gj70_gj7020: () => import("@/views/GJ70/GJ7020/index.vue"),
  gj70_gj7030: () => import("@/views/GJ70/GJ7030/index.vue"),
  gj80_gj8010: () => import("@/views/GJ80/GJ8010/index.vue"),
  gj80_gj8020: () => import("@/views/GJ80/GJ8020/index.vue"),
  gj80_gj8030: () => import("@/views/GJ80/GJ8030/index.vue"),
  gj80_gj8040: () => import("@/views/GJ80/GJ8040/index.vue"),
  gj80_gj8050: () => import("@/views/GJ80/GJ8050/index.vue"),
  gj80_gj8060: () => import("@/views/GJ80/GJ8060/index.vue"),
  gj80_gj8070: () => import("@/views/GJ80/GJ8070/index.vue"),
  gj80_gj8080: () => import("@/views/GJ80/GJ8080/index.vue"),
  gj80_gj8090: () => import("@/views/GJ80/GJ8090/index.vue"),
  gj80_gj8100: () => import("@/views/GJ80/GJ8100/index.vue"),
  403: () => import("@/views/_builtin/403/index.vue"),
  404: () => import("@/views/_builtin/404/index.vue"),
  500: () => import("@/views/_builtin/500/index.vue"),
  "iframe-page": () => import("@/views/_builtin/iframe-page/[url].vue"),
  login: () => import("@/views/_builtin/login/index.vue"),
  todo: () => import("@/views/_builtin/todo/index.vue"),
  home: () => import("@/views/home/index.vue"),
  "user-center": () => import("@/views/user-center/index.vue"),
};
