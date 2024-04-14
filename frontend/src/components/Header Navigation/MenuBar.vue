<script setup>
import ProductCategoryServices from "@/services/Product/ProductCategoryServices.js"
import {onMounted} from "vue";

onMounted(() => {
  console.log(ProductCategoryServices.getAllProductCategories());
})

</script>

<template>

</template>