<script setup>
import SidebarCategory from "@/components/Home/SidebarCategory.vue";
import {inject} from "vue";
import {Icon} from "@iconify/vue";

const isOpen = inject('isOpen');

const props = defineProps(['user']);

</script>

<template>
  <Transition
      enter-from-class="-translate-x-full"
      enter-active-class="transition-transform duration-500 ease-in-out"
      enter-to-class="translate-x-0"
      leave-from-class="translate-x-0"
      leave-active-class="transition-transform duration-200 ease-in-out"
      leave-to-class="-translate-x-full"
  >
    <div v-if="isOpen" class="w-4/6 fixed z-10  top-0 left-0 h-dvh">
      <div class="w-full h-full bg-white drop-shadow overflow-scroll">
        <div>
          <div class="p-4 bg-gray-200">
            <div v-if="user === null">
              <div class="">Hi there!</div>
              <div class="">
                <RouterLink class="font-bold" :to="{ name: 'login' }" >Log In</RouterLink>
                or
                <RouterLink class="font-bold" :to="{ name: 'register' }" >Sign Up</RouterLink>
              </div>
            </div>
            <div v-else>
              <RouterLink @click="isOpen = false" :to="{ name: 'profile'}" class="flex items-center justify-between">
                <div class="flex items-center">
                  <img src="../../../public/favicon.ico" alt="">
                  <div class="ml-4 font-bold">{{ props.user.userName }}</div>
                </div>
                <div>
                  <Icon class="w-8 h-8" icon="material-symbols:keyboard-arrow-right" />
                </div>
              </RouterLink>
            </div>
          </div>
          <SidebarCategory />
          <RouterLink class="px-4 pb-3 pt-8 block" to="">Delivery</RouterLink>
          <RouterLink class="px-4 py-3 block" to="">Returns</RouterLink>
          <RouterLink class="px-4 py-3 block" to="">Help Center</RouterLink>
          <RouterLink class="px-4 pt-3 pb-12 block" to="">Sell Your Art</RouterLink>
        </div>
      </div>
    </div>
  </Transition>
  <Transition
      enter-from-class="opacity-0"
      enter-active-class="transition-opacity duration-1000 ease-in-out"
      enter-to-class="opacity-100"
      leave-from-class="opacity-100"
      leave-active-class="transition-opacity duration-200 ease-in-out"
      leave-to-class="opacity-0"
      appear
  >
    <div v-if="isOpen" @click="isOpen = false" class="fixed top-0 right-0 w-full h-dvh bg-gray-500/45"
    ></div>
  </Transition>
</template>

