import API from "@/services/API.js";

export default {
    async registerAccount(data) {
        try {
            return await API().post("/authentication/register", data, {withCredentials: true});
        } catch (error) {
            console.log(error)
        }
    },

    async loginAccount(data) {
        try {
            return await API().post("/authentication/login", data, {withCredentials: true})
        } catch (error) {
            console.log(error)
        }
    },

    async refreshToken() {
        try {
            return await API().get("/authentication/refreshtoken", {withCredentials: true});
        } catch (error) {
            console.log(error)
        }
    }
}