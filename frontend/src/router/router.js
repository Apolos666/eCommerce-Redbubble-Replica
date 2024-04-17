import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'home',
    component: () => import("@/views/Home.vue")
  },
  {
    path: '/auth/register',
    name: 'register',
    component: () => import("@/views/Register.vue")
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
