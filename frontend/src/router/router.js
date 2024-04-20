import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'home',
    component: () => import("@/views/Home.vue")
  },
  {
    path: '/auth/',
    name: 'auth',
    component: () => import("@/views/Auth/AuthAccount.vue"),
    children: [
      {
        path: 'register',
        name: 'register',
        component: () => import("@/views/Auth/Register.vue")
      },
      {
        path: 'login',
        name: 'login',
        component: () => import("@/views/Auth/Login.vue")
      },
      {
        path: "account_recovery",
        name: "account_recovery",
        component: () => import("@/views/Auth/AccountRecovery.vue")
      }
    ]
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
