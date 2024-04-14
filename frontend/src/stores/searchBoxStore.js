import {defineStore} from "pinia";

export const useSearchBoxStore = defineStore('searchBox',{
    state: () => {
        return {
            inputValue: "",
            isSearchBoxClicked: false,
        }
    },
    actions: {
        setSearchBox(value) {
            this.isSearchBoxClicked = value;
        },
    }
});