<script setup>
import ProductCategoryServices from "@/services/Product/ProductCategoryServices.js"
import {onMounted, ref} from "vue";

const productCategories = ref([]);

onMounted( async () => {
  productCategories.value = await ProductCategoryServices.getAllProductCategories();
})

</script>

<template>
<div class="hidden lg:flex lg:items-center lg:justify-between lg:mx-2">
  <div class="p-2 font-normal">
    Explore designs
  </div>
  <div
      class="p-2 font-normal"
      v-for="(category, index) in productCategories"
      :key
  >
    {{ category.categoryName }}
  </div>
</div>
</template>