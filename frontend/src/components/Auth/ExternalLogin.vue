<script setup>

import {Icon} from "@iconify/vue";
</script>

<template>
  <form @submit.prevent class="flex flex-col space-y-4 m-4">
    <button class="p-4 text-white bg-[#4285F4] font-medium rounded-full text-base text-center inline-flex items-center justify-center">
      <Icon class="mr-4 w-6 h-6" icon="bi:google" />
      Sign in with Google
    </button>
    <button class="p-4 text-white bg-[#3b5998] font-medium rounded-full text-base text-center inline-flex items-center justify-center">
      <Icon class="mr-4 w-6 h-6" icon="bi:facebook" />
      Sign in with Facebook
    </button>
    <button class="p-4 text-white bg-[#1da1f2] font-medium rounded-full text-base text-center inline-flex items-center justify-center">
      <Icon class="mr-4 w-6 h-6" icon="bi:twitter" />
      Sign in with Twitter
    </button>
  </form>
</template>