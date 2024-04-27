<script setup>
const props = defineProps(['user'])

</script>

<template>
<RouterView :user="props.user"/>
</template>
