<script setup>

import {onBeforeMount} from "vue";
import AuthServices from "@/services/Auth/AuthServices.js";

onBeforeMount( async () => {
  await AuthServices.getMe()
})

</script>

<template>
  <RouterView :key="$route.path"></RouterView>
</template>