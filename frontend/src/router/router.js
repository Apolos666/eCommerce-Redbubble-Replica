import {createRouter, createWebHistory} from 'vue-router'
import User from "@/views/User/Parent/User.vue";

const routes = [
    {
        path: '/',
        name: 'index',
        component: () => import("@/views/Index.vue"),
        children: [
            {
                path: '/home/',
                name: 'home',
                component: () => import("@/views/Home.vue")
            },
            {
                path: '/user/',
                name: 'user',
                component: () => import("@/views/User/Parent/User.vue"),
                children: [
                    {
                        path: 'profile',
                        name: 'profile',
                        component: () => import("@/views/User/Profile.vue")
                    },
                    {
                        path: 'account-setting',
                        name: 'account-setting',
                        component: () => import("@/views/User/AccountSetting.vue")
                    }
                ]
            }
        ]
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