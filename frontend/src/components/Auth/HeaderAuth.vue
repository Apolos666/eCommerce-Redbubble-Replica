<script setup>
import { Icon } from '@iconify/vue'
</script>

<template>
  <div class="flex items-center justify-between">
    <div class="flex items-center">
      <div class="p-4 lg:p-8 2xl:hidden">
        <Icon class="text-2xl" icon="iconamoon:menu-burger-horizontal" />
      </div>
      <div class="2xl:ml-32">
        <RouterLink :to="{ name: 'home' }" class="flex items-center">
          <Icon class="text-4xl mr-2 lg:text-6xl" icon="logos:prestashop" />
          <p class="text-3xl font-bold font-mono lg:text-4xl">REDBUBBLE</p>
        </RouterLink>
      </div>
    </div>
    <div class="flex">
      <div class="my-4 m-x2 lg:m-8">
        <Icon class="text-3xl" icon="akar-icons:search" />
      </div>
      <div class="m-4 lg:m-8 2xl:mr-32">
        <Icon class="text-4xl" icon="ei:cart" />
      </div>
    </div>
  </div>
</template>
