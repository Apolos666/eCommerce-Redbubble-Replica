<script setup>
import * as yup from "yup";
import {useForm} from "vee-validate";
import CustomInput from "@/components/Utilities/CustomInput.vue";
import AuthServices from "@/services/Auth/AuthServices.js";
import {Icon} from "@iconify/vue";
import router from "@/router/router.js";

const schema = yup.object({
  emailAndUser: yup
      .string()
      .required('Email hoặc tên người dùng là bắt buộc'),
  password: yup
      .string()
      .min(6, 'Mật khẩu phải có ít nhất 6 ký tự')
      .matches(
          /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$/,
          'Mật khẩu phải chứa ít nhất một chữ cái viết hoa, một chữ cái viết thường và một số'
      )
      .required('Mật khẩu là bắt buộc'),
  isRemember: yup.boolean(),
});

const { values, errors, defineField, handleSubmit, isSubmitting } = useForm({
  validationSchema: schema,
});

const [emailAndUser, emailAndUserProps] = defineField("emailAndUser");
const [password, passwordProps] = defineField("password");
const [isRemember, isRememberProps] = defineField("isRemember");

const onSuccessSubmit = async (values) => {
  const response = await AuthServices.loginAccount({
    UserOrEmail: values.emailAndUser,
    Password: values.password,
  })

  console.log(response)
};

const onErrorSubmit = (errors) => {
  console.log(errors);
};

const onSubmit = handleSubmit(onSuccessSubmit, onErrorSubmit);

</script>

<template>
  <form @submit="onSubmit" class="flex flex-col">
    <CustomInput
      v-model.trim="emailAndUser"
      :error="errors.emailAndUser"
      class="mx-4 mt-4"
      title="Email or Username"
      input-type="text"
      v-bind="emailAndUserProps"
    />
    <CustomInput
      v-model.trim="password"
      :error="errors.password"
      class="mx-4 mt-4"
      title="Password"
      input-type="password"
      v-bind="passwordProps"
    />
    <div class="flex justify-between p-4 my-6">
      <div>
        <input
            type="checkbox"
            v-model="isRemember"
            class="mr-2 w-5 h-5 outline outline-2 outline-blue-500 outline-offset-[-1px]"
            v-bind="isRememberProps"
        />
        <label for="isRemember">Remember me</label>
      </div>
      <RouterLink :to="{ name: 'account_recovery'}">Lost Password?</RouterLink>
    </div>
    <div class="text-center text-slate-500 my-3">
      By clicking Log in, you agree to our <a href="" class="font-bold">User Agreement</a>
    </div>
    <button
        class="p-4 border-2 border-black m-4 text-white bg-pink-500 border-none rounded-full"
        :disabled="isSubmitting"
    >
      {{ isSubmitting ? 'Logging in' : 'Log in'}}
      <Icon v-if="isSubmitting" class="inline-block w-8" icon="line-md:loading-loop" />
    </button>
    <div class="text-center text-slate-500 mx-4">
      This is site protected by reCAPTCHA and the Google <a href="" class="font-bold">Privacy Policy</a> and <a href="" class="font-bold">Terms of Service</a> apply.
    </div>
  </form>
</template>