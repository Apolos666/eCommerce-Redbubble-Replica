import API from "@/services/API.js";

export default {
    async getAllPaymentTypes() {
        try {
            const response = await API().get("/paymenttypes", { withCredentials: true })
            return response.data;
        } catch (error) {
            console.log(error)
        }
    },
    async refreshToken() {
        try {
            const response = await API().get("/authentication/refreshtoken", { withCredentials: true })
            return response.data;
        } catch (error) {
            console.log(error)
        }
    }
}