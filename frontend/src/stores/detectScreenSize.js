import {defineStore} from "pinia";

export const useDetectScreenSize = defineStore('detectScreenSize',{
    state: () => {
    },
    getters: {
        isMobile: (state) => {
            return screen.width < 1024;
        },
        isTablet: (state) => {
            return screen.width >= 1024 && screen.width < 1536;
        },
        isDesktop: (state) => {
            return screen.width >= 1536;
        }
    },
    actions: {

    }
});