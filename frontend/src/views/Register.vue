<script setup>
import HeaderAuth from "@/components/Auth/HeaderAuth.vue";
import CustomInput from "@/components/Auth/CustomInput.vue";
import {useForm} from "vee-validate";
import * as yup from "yup";

const schema = yup.object({
  email: yup.string()
      .email("Email không hợp lệ")
      .required("Email là bắt buộc"),
  userName: yup.string()
      .min(6, "Tên người dùng phải có ít nhất 6 ký tự")
      .required("Tên người dùng là bắt buộc"),
  password: yup.string()
      .min(6, "Mật khẩu phải có ít nhất 6 ký tự")
      .matches(
          /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$/,
          "Mật khẩu phải chứa ít nhất một chữ cái viết hoa, một chữ cái viết thường và một số"
      )
      .required("Mật khẩu là bắt buộc"),
});

const {values, errors, defineField} = useForm({
  validationSchema: schema
})

const [email, emailProps] = defineField('email');
const [user, userProps] = defineField('userName');
const [password, passwordProps] = defineField('password');

</script>

<template>
<div>
  <HeaderAuth />
  <div class="text-center text-2xl mt-10">Join Redbubble</div>
  <CustomInput
      v-model="email"
      :error="errors.email"
      class="mx-4 mt-4"
      title="Email"
      v-bind="emailProps"
  />
  <CustomInput
      v-model="user"
      :error="errors.userName"
      class="mx-4 mt-2"
      title="Username"
      v-bind="userProps"
  />
  <CustomInput
      v-model="password"
      :error="errors.password"
      class="mx-4 mt-4"
      title="Password"
      v-bind="passwordProps"
  />
</div>
</template>
