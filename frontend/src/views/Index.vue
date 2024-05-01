<script setup>

import SidebarNavigation from "@/components/Home/SidebarNavigation.vue";
import HeaderNavigation from "@/components/Header Navigation/HeaderNavigation.vue";
import {onBeforeMount, provide, ref} from "vue";
import {useUserInfomation} from "@/composables/User/useUserInfomation.js";
import {useUserProfileImageStore} from "@/stores/User/UserProfile/UserProfileImageStore.js";

const isOpen = ref(false);
provide('isOpen', isOpen);

const { user } = useUserInfomation();
const userProfileImagePinia = useUserProfileImageStore();

onBeforeMount(() => {
  userProfileImagePinia.fetchUserProfileImage();
});

</script>

<template>
  <HeaderNavigation @OpenSideBarNavigation="isOpen = true"/>
  <SidebarNavigation :user="user"/>
  <RouterView :user="user"/>
</template>