/* eslint-disable */
/* prettier-ignore */
// Generated by elegant-router
// Read more: https://github.com/soybeanjs/elegant-router

import type { GeneratedRoute } from '@elegant-router/types'
export const generatedRoutes: GeneratedRoute[] = [
  {
    name: '403',
    path: '/403',
    component: 'layout.blank$view.403',
    meta: {
      title: '403',
      i18nKey: 'route.403',
      constant: true,
      hideInMenu: true,
    },
  },
  {
    name: '404',
    path: '/404',
    component: 'layout.blank$view.404',
    meta: {
      title: '404',
      i18nKey: 'route.404',
      constant: true,
      hideInMenu: true,
    },
  },
  {
    name: '500',
    path: '/500',
    component: 'layout.blank$view.500',
    meta: {
      title: '500',
      i18nKey: 'route.500',
      constant: true,
      hideInMenu: true,
    },
  },
  {
    name: 'gj10',
    path: '/gj10',
    component: 'layout.base',
    meta: {
      title: 'gj10',
      i18nKey: 'route.gj10',
      order: 2,
    },
    children: [
      {
        name: 'gj10_gj1010',
        path: '/gj10/gj1010',
        component: 'view.gj10_gj1010',
        meta: {
          title: 'gj10_gj1010',
          icon: '',
          roles: ['0'],
          i18nKey: 'route.gj10_gj1010',
        },
      },
      {
        name: 'gj10_gj1030',
        path: '/gj10/gj1030',
        component: 'view.gj10_gj1030',
        meta: {
          title: 'gj10_gj1030',
          icon: '',
          i18nKey: 'route.gj10_gj1030',
        },
      },
    ],
  },
  {
    name: 'gj80',
    path: '/gj80',
    component: 'layout.base',
    meta: {
      title: 'gj80',
      i18nKey: 'route.gj80',
      order: 3,
    },
    children: [
      {
        name: 'gj80_gj8090',
        path: '/gj80/gj8090',
        component: 'view.gj80_gj8090',
        meta: {
          title: 'gj80_gj8090',
          icon: '',
          i18nKey: 'route.gj80_gj8090',
        },
      },
    ],
  },
  {
    name: 'home',
    path: '/home',
    component: 'layout.base$view.home',
    meta: {
      title: 'home',
      i18nKey: 'route.home',
      icon: 'mdi:monitor-dashboard',
      order: 1,
    },
  },
  {
    name: 'iframe-page',
    path: '/iframe-page/:url',
    component: 'layout.base$view.iframe-page',
    props: true,
    meta: {
      title: 'iframe-page',
      i18nKey: 'route.iframe-page',
      constant: true,
      hideInMenu: true,
      keepAlive: true,
    },
  },
  {
    name: 'login',
    path: '/login/:module(pwd-login)?',
    component: 'layout.blank$view.login',
    props: true,
    meta: {
      title: 'login',
      i18nKey: 'route.login',
      constant: true,
      hideInMenu: true,
    },
  },
  {
    name: 'todo',
    path: '/todo',
    component: 'layout.base$view.todo',
    meta: {
      title: 'todo',
      i18nKey: 'route.todo',
      constant: true,
      hideInMenu: true,
    },
  },
  {
    name: 'user-center',
    path: '/user-center',
    component: 'layout.base$view.user-center',
    meta: {
      title: 'user-center',
      i18nKey: 'route.user-center',
      hideInMenu: true,
    },
  },
]
