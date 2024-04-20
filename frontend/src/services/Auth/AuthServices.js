import API from "@/services/API.js";

export default {
    async registerAccount(data) {
        try {
            const response = await API().post("/authentication/register", data)
            return response.data;
        } catch (error) {
            console.log(error)
        }
    }
}