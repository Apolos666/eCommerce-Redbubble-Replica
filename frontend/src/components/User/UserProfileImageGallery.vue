<script setup>
import useUserProfileImageGallery from "@/composables/User/useUserProfileImageGallery.js"

const {
  userProfileImagesBlob,
  selectedImageIndex,
  setSelectedImage,
  saveImage
} = useUserProfileImageGallery();
</script>

<template>
  <div class="mx-4 mt-6 grid grid-cols-3 gap-2">
    <div
        v-for="(imageUrl, index) in userProfileImagesBlob"
        :key="index"
        class="w-full h-32 border-black border-2 overflow-hidden"
        :class="[selectedImageIndex === index ? 'border-4 border-blue-400' : '']"
        @click="setSelectedImage(imageUrl.imageBlobUrl, imageUrl.absoluteUrl, index)"
    >
      <img :src="imageUrl.imageBlobUrl" alt="">
    </div>
  </div>
  <div @click="saveImage" class="mx-4 p-4 text-center bg-green-400 text-white rounded-lg mt-4">Save as primary profile picture</div>
</template>