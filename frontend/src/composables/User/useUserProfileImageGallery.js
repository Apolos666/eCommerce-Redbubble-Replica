import {onBeforeMount, ref} from "vue";
import UserImageServices from "@/services/User/UserImageServices.js";
import UserProfileServices from "@/services/User/UserProfileServices.js";
import {useUserProfileImageStore} from "@/stores/User/UserProfile/UserProfileImageStore.js";

export default function useUserProfileImageGallery() {
    const userProfile = useUserProfileImageStore();

    const userProfileImagesBlob = ref([]);
    const selectedImage = ref({imageBlobUrl: null, absoluteUrl: null});
    const selectedImageIndex = ref(null);

    const getUserProfileImages =  async () => {
        const userImagesUrl = await UserImageServices.getAllProfileImages();

        for (const url of userImagesUrl)
        {
            const imageBlobUrl = await UserProfileServices.getUserProfileImage(url);
            userProfileImagesBlob.value.push({imageBlobUrl: imageBlobUrl, absoluteUrl: url});
        }
    }

    const setSelectedImage = (imageBlobUrl , absoluteImageUrl, index) => {
        selectedImage.value.imageBlobUrl = imageBlobUrl;
        selectedImage.value.absoluteUrl = absoluteImageUrl;
        selectedImageIndex.value = index;
    }

    const saveImage = async () => {
        if (selectedImage.value === null)
            alert("Please select an image to save as primary profile picture.");

        const result = await UserImageServices.setActiveProfileImage(selectedImage.value.absoluteUrl);
        userProfile.updateUserProfileImage(selectedImage.value.imageBlobUrl);
    }

    onBeforeMount(async () => {
        await getUserProfileImages();
    });

    return {
        userProfileImagesBlob,
        selectedImageIndex,
        setSelectedImage,
        saveImage
    }
}