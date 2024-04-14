<script setup>
import {Icon} from "@iconify/vue";
import {computed, ref} from "vue";
import HeaderSearchBox from "@/components/Utilities/HeaderSearchBox.vue";
import DownloadLabelNotification from "@/components/Utilities/DownloadLabelNotification.vue";

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

</script>

<template>
<header>
  <div class="flex items-center justify-between">
    <div class="flex items-center">
      <button
          class="p-4"
          :class="[isBurgerMenuClicked ? 'rounded-full outline outline-lavender outline-offset-minus8 outline-4' : '']"
          @click="OnClickMenu(menuButtons.isBurgerMenuClicked, true)"
          @mouseleave="OnClickMenu(menuButtons.isBurgerMenuClicked, false)"
      >
        <Icon class="text-2xl" icon="radix-icons:hamburger-menu" />
      </button>
      <div class="flex items-center">
        <div class="pr-2">
          <Icon class="text-2xl" icon="logos:prestashop" />
        </div>
        <p class="font-bold text-xl "> REDBUBBLE </p>
      </div>
    </div>
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
  <HeaderSearchBox />
  <DownloadLabelNotification />
</header>
</template>
