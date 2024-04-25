<script setup>
import LoginForm from "@/components/Auth/LoginForm.vue";
import Test from "@/services/Test.js";

const test2 = async () => {
  await Test.refreshToken()
;}
</script>

<template>
  <div class="text-center text-2xl mt-14 font-semibold">Log In</div>
  <div class="text-center mt-2">
    Need an account?
    <RouterLink :to="{ name: 'register' }" class="font-bold">Sign up</RouterLink>
  </div>
  <LoginForm />
  <form>
    <div>Hello</div>
    <button @click.prevent="test2" class="p-4 border-black border-2">Click Me 2</button>
  </form>
</template>