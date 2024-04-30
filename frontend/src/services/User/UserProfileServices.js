import API from "@/services/API.js";

export default {
    async uploadProfileImage(formData) {
        try {
            const response = await API().post("/userprofile/upload-profile-image",
                formData,
                {
                    headers: {
                        'Content-Type': 'multipart/form-data',
                    },
                    withCredentials: true
                })

            return response.data;
        } catch (error) {
            console.log(error)
        }
    }
}