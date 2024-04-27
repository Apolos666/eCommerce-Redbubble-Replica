<script setup>

import SidebarNavigation from "@/components/Home/SidebarNavigation.vue";
import HeaderNavigation from "@/components/Header Navigation/HeaderNavigation.vue";
import {provide, ref} from "vue";
import {useUserInfomation} from "@/composables/User/useUserInfomation.js";

const isOpen = ref(false);
provide('isOpen', isOpen);

const { user } = useUserInfomation();

</script>

<template>
  <HeaderNavigation @OpenSideBarNavigation="isOpen = true"/>
  <SidebarNavigation :user="user"/>
  <RouterView :user="user"/>
</template>