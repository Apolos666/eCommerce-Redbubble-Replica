<script setup>
import {Icon} from "@iconify/vue";
import {ref} from "vue";
import {useSearchBoxStore} from "@/stores/searchBoxStore.js";
import {useDetectScreenSize} from "@/stores/detectScreenSize.js";

const searchBoxPinia = useSearchBoxStore();
const detectScreenSize = useDetectScreenSize()

const searchContent = ref(['Find neon ice cream', 'Search for cat pun t-shirts', 'Search for Stranger thing fan'])
const currentSearchContent = ref('Find neon ice cream');

const searchContentTimeOut = 3000;
let searchContentIndex = 0;

setInterval(() => {
  searchContentIndex++;
  currentSearchContent.value = searchContent.value[searchContentIndex % searchContent.value.length];
}, searchContentTimeOut);

</script>

<template>
  <form class="mx-2 mt-2 flex items-center justify-between" action="">
    <div
        class="flex items-center justify-between overflow-hidden outline rounded-lg w-full"
        :class="[searchBoxPinia.isSearchBoxClicked ? 'outline-lavender' : 'outline-green-500',
        detectScreenSize.isTablet || detectScreenSize.isDesktop ? '' : 'w-85Percent']"
    >
      <div class="flex-grow">
        <input
            class="outline-none p-3 w-full"
            type="text"
            v-model="searchBoxPinia.inputValue"
            :placeholder="currentSearchContent"
            @click="searchBoxPinia.setSearchBox(true)"
            @blur="detectScreenSize.isTablet || detectScreenSize.isDesktop ? searchBoxPinia.setSearchBox(false) : null"
        >
      </div>
      <div class="mr-4">
        <Icon class="text-3xl" icon="akar-icons:search" />
      </div>
    </div>
    <div
        v-if="!(detectScreenSize.isTablet || detectScreenSize.isDesktop) && searchBoxPinia.isSearchBoxClicked"
        class="w-15Percent"
        @click="searchBoxPinia.setSearchBox(false)">
      <Icon class="text-3xl mx-auto" icon="material-symbols-light:cancel-outline" />
    </div>
  </form>
</template>

<style scoped>
</style>