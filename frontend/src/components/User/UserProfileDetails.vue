<script setup>
const props = defineProps(['user'])

</script>

<template>
  <div class="p-8 shadow">
    <div class="flex items-center ">
      <div class="bg-white border-[1px] border-green-400 rounded-full p-4">
        <img class="w-16 h-16" src="../../../public/favicon.ico" alt="">
      </div>
      <div class="ml-10">
        <div class="font-bold text-2xl">About {{ props.user.userName}}</div>
        <div class="text-sm mt-2">Joined April 2024.</div>
      </div>
    </div>
    <div class="flex items-center justify-between my-6">
      <div class="text-center">
        <div class="font-bold text-xl">0</div>
        <div class="">Followers</div>
      </div>
      <div class="text-center">
        <div class="font-bold text-xl">0</div>
        <div class="">Following</div>
      </div>
      <div class="text-center">
        <div class="font-bold text-xl">0</div>
        <div class="">Favorited</div>
      </div>
    </div>
  </div>
</template>
