import {defineStore} from "pinia";

export const useUserProfileStore = defineStore('userProfileStore',{
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
        }
    }
});