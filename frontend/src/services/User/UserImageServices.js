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
    },
    async getAllProfileImages() {
        try {
            const response = await API().get("/userimages/get-all-profile-images", {
                withCredentials: true,
            });

            return response.data;
        } catch (error) {
            console.log(error)
        }
    },
    async setActiveProfileImage(imageUrl) {
        try {
            const response = await API().post("/userimages/set-active-profile-image", null, {
                params: {
                    imageUrl: imageUrl
                },
                withCredentials: true
            });
        } catch (error) {
            console.log(error)
        }
    }
}