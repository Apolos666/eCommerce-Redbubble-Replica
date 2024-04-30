<script setup>

import UserProfileDetails from "@/components/User/UserProfileDetails.vue";
import Block from "@/components/Utilities/Block.vue";

const props = defineProps(['user'])

</script>

<template>
  <Block />
  <UserProfileDetails :user="props.user"/>
  <Block />
</template>