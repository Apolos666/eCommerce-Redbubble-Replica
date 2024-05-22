import { createApp } from 'vue'
import { createPinia } from 'pinia'
import '@/css/tailwind/index.css'
import App from './App.vue'
import router from './router/router.js'
import vue3GoogleLogin from 'vue3-google-login'

const app = createApp(App)

app.use(vue3GoogleLogin, {
    clientId: import.meta.env.VITE_GOOGLE_CLIENT_ID,
})
app.use(createPinia())
app.use(router)
app.mount('#app')
