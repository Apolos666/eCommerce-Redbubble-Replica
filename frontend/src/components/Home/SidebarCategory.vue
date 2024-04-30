<script setup>
import {Icon} from "@iconify/vue";
</script>

<template>
  <div v-for="n in 12"
      class="px-4 py-6 flex items-center justify-between border-b-gray-300 border-b-[1px]"
  >
    <div class="flex items-center">
      <img src="../../../public/favicon.ico" alt="">
      <div class="ml-4">Explore design</div>
    </div>
    <div>
      <Icon class="w-8 h-8" icon="material-symbols:keyboard-arrow-right" />
    </div>
  </div>
</template>