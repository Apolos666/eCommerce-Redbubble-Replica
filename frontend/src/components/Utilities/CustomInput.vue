<script setup>
import {ref} from 'vue'
import {Icon} from "@iconify/vue";

defineOptions({
  inheritAttrs: false
})

const props = defineProps({
  error: String,
  modelValue: String,
  title: String,
  inputType: String
})

const emit = defineEmits(['update:modelValue', 'blur'])

const isShowPassword = ref(false)

const displayType = () => {
  if (props.inputType === 'password') {
    if (isShowPassword.value) {
      return 'text'
    } else {
      return 'password'
    }
  } else {
    return props.inputType
  }
}

</script>

<template>
  <div v-bind="$attrs">
    <div class="input-parent">
      <input
          :type="displayType()"
          :value="modelValue"
          autocomplete="off"
          class="focus:mb-2 valid:mb-2"
          name="name"
          required
          @blur="$emit('blur')"
          @input="$emit('update:modelValue', $event.target.value)"
      />
      <label class="label-name" for="name">
        <span class="content-name mb-2"> {{ title }} </span>
      </label>
      <div
          class="absolute top-2/3 right-2"
      >
        <Icon v-if="inputType === 'password' && isShowPassword"
              icon="mdi:eye"
              @click="isShowPassword = !isShowPassword"
        />
        <Icon v-else-if="inputType === 'password' && !isShowPassword"
              icon="ion:eye-off"
              @click="isShowPassword = !isShowPassword"
        />
      </div>
    </div>
    <span class="text-red-500">{{ error }} </span>
  </div>
</template>

<style scoped>
.input-parent {
  position: relative;
  overflow: hidden;
  margin-bottom: 10px;
}

.input-parent input {
  width: 100%;
  height: 100%;
  color: #5fa8d3;
  padding-top: 35px;
  border: none;
  outline: none;
}

.input-parent label {
  position: absolute;
  width: 100%;
  height: 100%;
  bottom: 0px;
  left: 0%;
  pointer-events: none;
  border-bottom: 1px solid black;
}

.input-parent label::after {
  content: '';
  position: absolute;
  width: 100%;
  height: 100%;
  border-bottom: 3px solid #5fa8d3;
  bottom: -1px;
  left: 0px;
  transform: translateX(-100%);
  transition: all 0.3s ease;
}

.content-name {
  position: absolute;
  bottom: -2px;
  left: 0px;
  transition: all 0.3s ease;
}

.input-parent input:focus + .label-name .content-name,
.input-parent input:valid + .label-name .content-name {
  transform: translateY(-150%);
  font-size: 14px;
  color: #5fa8d3;
}

.input-parent input:focus + .label-name::after,
.input-parent input:valid + .label-name::after {
  transform: translateX(0%);
}
</style>
