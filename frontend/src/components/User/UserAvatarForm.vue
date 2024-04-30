<script setup>
import {ref} from "vue";
import UserProfileServices from "@/services/User/UserProfileServices.js";
import {Icon} from "@iconify/vue";

defineOptions({
  inheritAttrs: false
})


const { handleSubmit, isSubmitting} = useForm();

const selectedFile = ref(null)

const handleFileChange = (event) => {
  selectedFile.value = event.target.files[0];
}

const handleFileUpload = async (event) => {
  const formData = new FormData();
  formData.append('file', selectedFile.value);

  const result = await UserProfileServices.uploadProfileImage(formData);
  console.log(result);

  selectedFile.value = null;
}

const onSubmit = handleSubmit(handleFileUpload);

</script>

<template>
  <form @submit.prevent="onSubmit" v-bind="$attrs">
    <div class="block font-bold text-lg">Choose image</div>
    <label class="block mt-2 px-6 py-2 rounded-lg bg-green-400 border-green-600 border-b-[4px] text-white text-center" for="image-file">Choose File</label>
    <input @change="handleFileChange" class="mt-2 hidden" type="file" id="image-file" accept="image/*">
    <button
        :disabled="selectedFile === null || isSubmitting"
        class="mt-3 cursor-pointer transition-all text-white px-6 py-2 rounded-lg
            border-blue-600
            border-b-[4px] hover:brightness-110 hover:-translate-y-[1px] hover:border-b-[6px]
            active:border-b-[2px] active:brightness-90 active:translate-y-[2px]
        "
        :class="[selectedFile === null ? 'bg-blue-200' : 'bg-blue-500']"
    >
      {{ isSubmitting ? 'Uploading' : 'Upload'}}
      <Icon v-if="isSubmitting" class="inline-block w-8" icon="line-md:loading-loop" />
    </button>
  </form>
</template>