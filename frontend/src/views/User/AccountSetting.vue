<script setup>

import Block from "@/components/Utilities/Block.vue";
import UserAvatarForm from "@/components/User/UserAvatarForm.vue";


</script>

<template>
  <Block></Block>
  <div class="mx-4">
    <div class="text-xl font-bold border-b-gray-300 py-4 border-b-2">Avatar</div>
  </div>
  <div class="mx-4 mt-6 flex">
    <div class="">
      <img src="../../../public/favicon.ico" class="w-20 h-20 border-black border-2 rounded-full" alt="">
    </div>
    <UserAvatarForm class="ml-4"/>
  </div>
  <div class="mx-4 mt-10 font-medium text-base">You can inject a little more personality into your profile and help people recognize you across Redbubble by uploading an avatar (an image, photo or other graphic icon of "you").</div>
</template>