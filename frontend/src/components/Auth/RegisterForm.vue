<script setup>
import CustomInput from '@/components/Utilities/CustomInput.vue'
import { useForm } from 'vee-validate'
import * as yup from 'yup'
import {Icon} from "@iconify/vue";
import AuthServices from "@/services/Auth/AuthServices.js";

const schema = yup.object({
  email: yup.string().email('Email không hợp lệ').required('Email là bắt buộc'),
  userName: yup
      .string()
      .min(6, 'Tên người dùng phải có ít nhất 6 ký tự')
      .required('Tên người dùng là bắt buộc'),
  password: yup
      .string()
      .min(6, 'Mật khẩu phải có ít nhất 6 ký tự')
      .matches(
          /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$/,
          'Mật khẩu phải chứa ít nhất một chữ cái viết hoa, một chữ cái viết thường và một số'
      )
      .required('Mật khẩu là bắt buộc'),
  confirmPassword: yup
      .string()
      .oneOf([yup.ref('password'), null], 'Mật khẩu xác nhận không khớp')
      .required('Xác nhận mật khẩu là bắt buộc'),
})

const { values, errors, defineField, handleSubmit, isSubmitting } = useForm({
  validationSchema: schema
})

const [email, emailProps] = defineField('email')
const [user, userProps] = defineField('userName')
const [password, passwordProps] = defineField('password')
const [confirmPassword, confirmPasswordProps] = defineField('confirmPassword')
const [isChecked, isCheckedProps] = defineField('isChecked')

const onSuccessSubmit = async (values) => {
  const response = await AuthServices.registerAccount({
    UserEmail: values.email,
    UserName: values.userName,
    Password: values.password,
  })

  console.log(response);
}

const onErrorSubmit = (errors) => {
  console.log(errors)
}

const onSubmit = handleSubmit(onSuccessSubmit, onErrorSubmit);

</script>

<template>
  <form @submit="onSubmit" class="flex flex-col">
    <CustomInput
        v-model.trim="email"
        :error="errors.email"
        class="mx-4 mt-4"
        title="Email"
        input-type="text"
        v-bind="emailProps"
    />
    <CustomInput
        v-model.trim="user"
        :error="errors.userName"
        class="mx-4 mt-2"
        title="Username"
        input-type="text"
        v-bind="userProps"
    />
    <CustomInput
        v-model.trim="password"
        :error="errors.password"
        class="mx-4 mt-4"
        title="Password"
        input-type="password"
        v-bind="passwordProps"
    />
    <CustomInput
        v-model.trim="confirmPassword"
        :error="errors.confirmPassword"
        class="mx-4 mt-4"
        title="Confirm Password"
        input-type="password"
        v-bind="confirmPasswordProps"
    />
    <div class="flex p-4 my-2">
      <input
          v-model="isChecked"
          v-bind="isCheckedProps"
          type="checkbox"
          class="mr-2 w-5 h-5 outline outline-2 outline-blue-500 outline-offset-[-1px]"
      >
      <p>Email me special offers and artist news</p>
    </div>
    <button
        class="p-4 border-2 border-black mx-4 text-white bg-pink-500 border-none rounded-full"
        :disabled="isSubmitting"
    >
      {{ isSubmitting ? 'Loading' : 'Submit'}}
      <Icon v-if="isSubmitting" class="inline-block w-8" icon="line-md:loading-loop" />
    </button>
  </form>
</template>
