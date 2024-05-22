<script setup lang="ts">

import {Icon} from "@iconify/vue";
import AuthServices from "@/services/Auth/AuthServices.js";
import {decodeCredential, GoogleLogin} from "vue3-google-login";

const callback = (response) => {
  // This callback will be triggered when the user selects or login to
  // his Google account from the popup
  console.log("Handle the response", response)
  const userData = decodeCredential(response.credential)
  console.log("Handle the userData", userData)
}

const externalLogin = async (provider) => {
  await AuthServices.externalLogin(provider);
}

</script>

<template>
  <GoogleLogin :callback="callback" prompt/>
<!--  <form @submit.prevent class="flex flex-col space-y-4 m-4">-->
<!--    <button @click="externalLogin('Google')" class="p-4 text-white bg-[#4285F4] font-medium rounded-full text-base text-center inline-flex items-center justify-center">-->
<!--      <Icon class="mr-4 w-6 h-6" icon="bi:google" />-->
<!--      Sign in with Google-->
<!--    </button>-->
<!--    <button @click="externalLogin('Facebook')" class="p-4 text-white bg-[#3b5998] font-medium rounded-full text-base text-center inline-flex items-center justify-center">-->
<!--      <Icon class="mr-4 w-6 h-6" icon="bi:facebook" />-->
<!--      Sign in with Facebook-->
<!--    </button>-->
<!--    <button @click="externalLogin('Twitter')" class="p-4 text-white bg-[#1da1f2] font-medium rounded-full text-base text-center inline-flex items-center justify-center">-->
<!--      <Icon class="mr-4 w-6 h-6" icon="bi:twitter" />-->
<!--      Sign in with Twitter-->
<!--    </button>-->
<!--  </form>-->
</template>