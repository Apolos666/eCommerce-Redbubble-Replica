import {ref} from "vue";
import UserProfileServices from "@/services/User/UserProfileServices.js";
import {useForm} from "vee-validate";
import {useUserProfileImageStore} from "@/stores/User/UserProfile/UserProfileImageStore.js";

export default function useUserAvatarForm() {
    const userProfileImagePinia = useUserProfileImageStore();

    const selectedFile = ref(null);

    const { handleSubmit, isSubmitting} = useForm();

    const handleFileChange = (event) => {
        selectedFile.value = event.target.files[0];
    }

    const handleFileUpload = async (event) => {
        const formData = new FormData();
        formData.append('file', selectedFile.value);

        const result = await UserProfileServices.uploadProfileImage(formData);
        const imageUrl = await UserProfileServices.getUserProfileImage(result);
        userProfileImagePinia.updateUserProfileImage(imageUrl);

        selectedFile.value = null;
    }

    const onSubmit = handleSubmit(handleFileUpload);

    return {
        selectedFile,
        isSubmitting,
        handleFileChange,
        onSubmit
    }
}