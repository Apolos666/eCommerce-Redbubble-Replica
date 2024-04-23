import API from "@/services/API.js";

export default {
    async registerAccount(data) {
        try {
            const response = await API().post("/authentication/register", data, { withCredentials: true })
            return response.data;
        } catch (error) {
            console.log(error)
        }
    },

    async loginAccount(data) {
        try {
            const response = await API().post("/authentication/login", data, { withCredentials: true })
            return response.data;
        } catch (error) {
            console.log(error)
        }
    }
}