<script setup>
import {Icon} from "@iconify/vue";
import {computed, onMounted, ref, watchEffect} from "vue";
import HeaderSearchBox from "@/components/Utilities/HeaderSearchBox.vue";
import DownloadLabelNotification from "@/components/Utilities/DownloadLabelNotification.vue";
import {useDetectScreenSize} from "@/stores/detectScreenSize.js";
import MenuBar from "@/components/Header Navigation/MenuBar.vue";

const emit = defineEmits(['OpenSideBarNavigation']);

const detectScreenSizePinia = useDetectScreenSize()

const isBurgerMenuClicked = ref(false);
const isHeartClicked = ref(false);
const isCartClicked = ref(false);

// Prevent unwarp when using in template
const menuButtons = {
  isBurgerMenuClicked,
  isHeartClicked,
  isCartClicked
}

const OnClickMenu = (typeMenu, value) => {
  typeMenu.value = value;
};

watchEffect(() => {
  if (isBurgerMenuClicked.value)
    emit('OpenSideBarNavigation')
})

</script>

<template>
<header>
  <div class="flex items-center justify-between mx-4 my-2 lg:justify-stretch lg:mb-4">
    <div class="flex items-center">
      <button
          class="p-4 lg:hidden"
          :class="[isBurgerMenuClicked ? 'rounded-full outline outline-lavender outline-offset-minus8 outline-4' : '']"
          @click="OnClickMenu(menuButtons.isBurgerMenuClicked, true)"
          @mouseleave="OnClickMenu(menuButtons.isBurgerMenuClicked, false)"
      >
        <Icon class="text-2xl" icon="radix-icons:hamburger-menu" />
      </button>
      <RouterLink :to="{ name: 'home' }" class="flex items-center lg:pl-4">
        <div class="pr-2">
          <Icon class="text-2xl lg:text-4xl" icon="logos:prestashop" />
        </div>
        <p class="font-bold text-xl "> REDBUBBLE </p>
      </RouterLink>
    </div>
    <HeaderSearchBox class="lg:mx-4 lg:w-full" v-if="detectScreenSizePinia.isDesktop || detectScreenSizePinia.isTablet"/>
    <div class="hidden lg:block text-lg font-semibold lg:mx-6 lg:text-nowrap">Sell your art</div>
    <div class="hidden lg:block text-lg font-semibold lg:mx-6 lg:text-nowrap">Login</div>
    <div class="hidden lg:block text-lg font-semibold lg:mx-6 lg:text-nowrap">Signup</div>
    <div class="flex">
      <div
          class="p-4"
          :class="[isHeartClicked ? 'rounded-full outline outline-lavender outline-offset-minus8 outline-4' : '']"
          @click="OnClickMenu(menuButtons.isHeartClicked, true)"
          @mouseleave="OnClickMenu(menuButtons.isHeartClicked, false)"
      >
        <Icon class="text-2xl" icon="mdi:heart-outline" />
      </div>
      <div
          class="p-4"
          :class="[isCartClicked ? 'rounded-full outline outline-lavender outline-offset-minus8 outline-4' : '']"
          @click="OnClickMenu(menuButtons.isCartClicked, true)"
          @mouseleave="OnClickMenu(menuButtons.isCartClicked, false)"
      >
        <Icon class="text-2xl" icon="ion:cart-outline" />
      </div>
    </div>
  </div>
  <HeaderSearchBox v-if="detectScreenSizePinia.isMobile" />
  <MenuBar />
  <DownloadLabelNotification />
</header>
</template>
