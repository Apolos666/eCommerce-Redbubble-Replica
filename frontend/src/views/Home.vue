<script setup>
import HeaderNavigation from "@/components/Header Navigation/HeaderNavigation.vue";
import SidebarNavigation from "@/components/Home/SidebarNavigation.vue";
import {ref, provide} from "vue";

const isOpen = ref(false);
provide('isOpen', isOpen);

</script>

<template>
  <HeaderNavigation @OpenSideBarNavigation="isOpen = true"/>
  <SidebarNavigation />
  <RouterLink :to=" {name: 'register'} ">Register</RouterLink>
</template>
