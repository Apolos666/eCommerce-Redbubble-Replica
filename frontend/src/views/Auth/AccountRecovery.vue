<script setup>
const handleAccountRecovery = (event) => {
  alert('Account recovery is not yet implemented.');
}
</script>

<template>
  <div class="mx-8">
    <h1 class="font-bold text-2xl my-6">Recover Your Account</h1>
    <div class="font-bold">Forgot your password?</div>
    <div class="text-slate-900 my-1">Happens to us all the time. That's why we changed all of our passwords to "password". Just kidding.</div>
    <div class="mt-4">We recommend you choose a <a href="" class="inline-block underline">strong password</a> and even use a <a href="" class="inline-block underline">password manager</a> like we do.</div>
    <div class="mt-4">Just enter the email you used to sign up and we'll help you sort this out.</div>
    <div class="mt-8">
      <div>Email Address</div>
      <form @submit.prevent="handleAccountRecovery" class="mt-2 flex flex-col">
        <input type="text" placeholder="Enter your email address"
               class="w-full outline-none border-2 border-gray-300 py-2 px-4 focus:border-blue-500 transition-colors duration-200"
        >
        <button
            class="p-4 border-2 border-black my-6 text-white bg-pink-500 border-none rounded-full"
        >
          Recover My Account
        </button>
      </form>
    </div>
    <div>Problems? <a href="" class="font-bold underline my-4">Contact us</a></div>
    <div class="text-slate-500 text-sm my-4">
      This is site protected by reCAPTCHA and the Google <a href="" class="font-bold">Privacy Policy</a> and <a href="" class="font-bold">Terms of Service</a> apply.
    </div>
  </div>
</template>
