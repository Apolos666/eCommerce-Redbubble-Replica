import AuthServices from "@/services/Auth/AuthServices.js";
import {onBeforeMount, ref} from "vue";

export function useUserInfomation() {
    const user = ref(null)
    const error = ref(null)
    const loading = ref(false)

    async function load() {
        loading.value = true
        try {
            const response = await AuthServices.getMe()
            user.value = response.data
        } catch (err) {
            error.value = err
        } finally {
            loading.value = false
        }
    }

    onBeforeMount( async () => {
        await load();
    })

    return { user, error, loading, load }
}