import API from "@/services/API.js";

export default {
    async getCurrentActiveProfileImageUrl() {
        try {
            const response = await API().get("/userimages/get-current-active-profile-image-url", {
                withCredentials: true,
            });

            return  response.data;
        } catch (error) {
            console.log(error)
        }
    }
}