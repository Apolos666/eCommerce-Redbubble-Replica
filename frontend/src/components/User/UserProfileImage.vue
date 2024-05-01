<script setup>
import UserAvatarForm from "@/components/User/UserAvatarForm.vue";
import {useUserProfileImageStore} from "@/stores/User/UserProfile/UserProfileImageStore.js";
import UserProfileImageGallery from "@/components/User/UserProfileImageGallery.vue";

const userProfile = useUserProfileImageStore();
</script>

<template>
  <div class="mx-4">
    <div class="text-xl font-bold border-b-gray-300 py-4 border-b-2">Avatar</div>
  </div>
  <div class="mx-4 mt-6 flex">
    <div class="">
      <img :src="userProfile.userProfileImage" alt="" class="w-20 h-20 border-black border-2 rounded-full">
    </div>
    <UserAvatarForm class="ml-4"/>
  </div>
  <UserProfileImageGallery />
  <div class="mx-4 mt-10 font-medium text-base">You can inject a little more personality into your profile and help
    people recognize you across Redbubble by uploading an avatar (an image, photo or other graphic icon of "you").
  </div>
</template>