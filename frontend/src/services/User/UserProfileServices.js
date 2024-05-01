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
    },
    async getUserProfileImage(url) {
        try {
            const response = await API().get("/userprofile/get-profile-image", {
                params: {
                    url: url
                },
                withCredentials: true,
                responseType: 'blob'
            });

            const urlCreator = window.URL || window.webkitURL;
            return urlCreator.createObjectURL(response.data);
        } catch (error) {
            console.log(error)
        }
    }
}