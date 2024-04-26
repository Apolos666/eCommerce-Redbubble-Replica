<script setup>
import SidebarCategory from "@/components/Home/SidebarCategory.vue";
import {inject} from "vue";

const isOpen = inject('isOpen');
</script>

<template>
  <div v-if="isOpen" class="fixed top-0 left-0 w-full h-dvh flex">
    <div class="w-4/6 h-full bg-white drop-shadow overflow-scroll">
      <div>
        <div class="p-4 bg-gray-200">
          <div class="">Hi there!</div>
          <div class="">
            <RouterLink class="font-bold" :to="{ name: 'login' }" >Log In</RouterLink>
            or
            <RouterLink class="font-bold" :to="{ name: 'register' }" >Sign Up</RouterLink>
          </div>
        </div>
        <SidebarCategory />
        <RouterLink class="px-4 pb-3 pt-8 block" to="">Delivery</RouterLink>
        <RouterLink class="px-4 py-3 block" to="">Returns</RouterLink>
        <RouterLink class="px-4 py-3 block" to="">Help Center</RouterLink>
        <RouterLink class="px-4 pt-3 pb-12 block" to="">Sell Your Art</RouterLink>
      </div>
    </div>
    <div @click="isOpen = false" class="w-2/6 bg-gray-500/45"></div>
  </div>
</template>
