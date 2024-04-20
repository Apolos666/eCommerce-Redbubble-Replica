<script setup>

import HeaderAuth from "@/components/Auth/HeaderAuth.vue";
import LoginForm from "@/components/Auth/LoginForm.vue";
import FooterAuth from "@/components/Auth/FooterAuth.vue";
</script>

<template>
  <div class="text-center text-2xl mt-14 font-semibold">Log In</div>
  <div class="text-center mt-2">
    Need an account?
    <RouterLink :to="{ name: 'register' }" class="font-bold">Sign up</RouterLink>
  </div>
  <LoginForm />
</template>