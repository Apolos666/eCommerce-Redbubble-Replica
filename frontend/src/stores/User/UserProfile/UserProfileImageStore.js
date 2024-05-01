import {defineStore} from "pinia";
import UserImageServices from "@/services/User/UserImageServices.js";
import UserProfileServices from "@/services/User/UserProfileServices.js";

export const useUserProfileImageStore = defineStore('userProfileStore',{
    state: () => {
        return {
            userProfileImage: null,
        }
    },
    getters: {

    },
    actions: {
        updateUserProfileImage(imageUrl) {
            this.userProfileImage = imageUrl;
        },

        async fetchUserProfileImage() {
            const currentActiveProfileImageUrl = await UserImageServices.getCurrentActiveProfileImageUrl();
            const imageUrl = await UserProfileServices.getUserProfileImage(currentActiveProfileImageUrl);
            this.userProfileImage = imageUrl;
        }
    }
});