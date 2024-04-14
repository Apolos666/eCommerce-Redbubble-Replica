import API from "@/services/API.js";

export default {
    async getAllProductCategories() {
        try {
            const response = await API().get("/productcategorys")
            return response.data;
        } catch (error) {
            console.log(error)
        }
    }
}