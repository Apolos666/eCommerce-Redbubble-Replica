<script setup>
import {ref} from "vue";

defineOptions({
  inheritAttrs: false
})

const selectedFile = ref(null)

const handleFileChange = (event) => {
  selectedFile.value = event.target.files[0];
}

const handleFileUpload = (event) => {

}

</script>

<template>
  <form @submit.prevent v-bind="$attrs">
    <div class="block font-bold text-lg">Choose image</div>
    <label class="block mt-2 px-6 py-2 rounded-lg bg-green-400 border-green-600 border-b-[4px] text-white" for="image-file">Choose File</label>
    <input @change="handleFileChange" class="mt-2 hidden" type="file" id="image-file" accept="image/*">
    <button
        @click="handleFileUpload"
        :disabled="selectedFile === null"
        class="mt-3 cursor-pointer transition-all text-white px-6 py-2 rounded-lg
            border-blue-600
            border-b-[4px] hover:brightness-110 hover:-translate-y-[1px] hover:border-b-[6px]
            active:border-b-[2px] active:brightness-90 active:translate-y-[2px]"
        :class="[selectedFile === null ? 'bg-blue-200' : 'bg-blue-500']"
    >
      Upload
    </button>
  </form>
</template>