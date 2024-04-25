<script setup>
import RegisterForm from "@/components/Auth/RegisterForm.vue";
</script>

<template>
  <div>
    <div class="text-center text-2xl mt-10">Join Redbubble</div>
    <div class="text-center mt-5">Sign up as customer for 20% off your first order. Your coupon will be emailed after sign up.</div>
    <RegisterForm />
    <div class="text-center my-4">
      Already have an account?
      <RouterLink :to="{ name: 'login' }" class="font-bold">Log in</RouterLink>
    </div>
    <div class="text-center mx-4 text-slate-500 text-sm">
      By clicking Sign Up, you agree to our <a href="" class="font-bold">User Agreement</a> and <a href="" class="font-bold">Privacy Policy</a>.
    </div>
    <div class="text-center m-4 text-slate-500 text-sm">
      This site is protected by reCAPTCHA and the Google <a href="" class="font-bold">Privacy Policy</a> and <a href="" class="font-bold">Terms of Service</a> apply.
    </div>
  </div>
</template>
