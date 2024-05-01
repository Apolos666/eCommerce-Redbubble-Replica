<script setup>

import {onBeforeMount, ref} from "vue";
import UserImageServices from "@/services/User/UserImageServices.js";
import UserProfileServices from "@/services/User/UserProfileServices.js";
import {useUserProfileImageStore} from "@/stores/User/UserProfile/UserProfileImageStore.js";

const userProfile = useUserProfileImageStore();

const userProfileImagesBlob = ref([]);
const selectedImage = ref({imageBlobUrl: null, absoluteUrl: null});
const selectedImageIndex = ref(null);

const getUserProfileImages =  async () => {
  const userImagesUrl = await UserImageServices.getAllProfileImages();

  for (const url of userImagesUrl)
  {
    const imageBlobUrl = await UserProfileServices.getUserProfileImage(url);
    userProfileImagesBlob.value.push({imageBlobUrl: imageBlobUrl, absoluteUrl: url});
  }
}

const selectImage = (imageBlobUrl ,absoluteImageUrl, index) => {
  selectedImage.value.imageBlobUrl = imageBlobUrl;
  selectedImage.value.absoluteUrl = absoluteImageUrl;
  selectedImageIndex.value = index;
}

const saveImage = async () => {
  if (selectedImage.value === null)
    alert("Please select an image to save as primary profile picture.");

  const result = await UserImageServices.setActiveProfileImage(selectedImage.value.absoluteUrl);
  userProfile.updateUserProfileImage(selectedImage.value.imageBlobUrl);
}

onBeforeMount(() => {
  getUserProfileImages();
});

</script>

<template>
  <div class="mx-4 mt-6 grid grid-cols-3 gap-2">
    <div
        v-for="(imageUrl, index) in userProfileImagesBlob"
        :key="index"
        class="w-full h-32 border-black border-2 overflow-hidden"
        :class="[selectedImageIndex === index ? 'border-4 border-blue-400' : '']"
        @click="selectImage(imageUrl.imageBlobUrl, imageUrl.absoluteUrl, index)"
    >
      <img :src="imageUrl.imageBlobUrl" alt="">
    </div>
  </div>
  <div @click="saveImage" class="mx-4 p-4 text-center bg-green-400 text-white rounded-lg mt-4">Save as primary profile picture</div>
</template>