<script setup>

import HeaderAuth from "@/components/Auth/HeaderAuth.vue";
import FooterAuth from "@/components/Auth/FooterAuth.vue";
</script>

<template>
  <HeaderAuth />
  <RouterView />
  <FooterAuth />
</template>