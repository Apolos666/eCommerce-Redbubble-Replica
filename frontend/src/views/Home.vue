<script setup>
import HeaderNavigation from "@/components/Header Navigation/HeaderNavigation.vue";
</script>

<template>
  <HeaderNavigation />
  <RouterLink :to=" {name: 'register'} ">Register</RouterLink>
</template>
