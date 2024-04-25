import axios from "axios";
import router from "../router/router.js";

export default (url='http://localhost:5258/api') => {
    const instance = axios.create({
        baseURL: url,
    })

    const refreshTokenInstance = axios.create({
        baseURL: url,
    });

    instance.interceptors.response.use(async function  (response) {
        return response;
    }, async function (error) {
        if (error.response.status === 401) {
            try {
                let refreshTokenResult = await refreshTokenInstance.get('/authentication/refreshtoken', { withCredentials: true });
                return instance(error.config);
            } catch (refreshTokenError) {
                if (refreshTokenError.response && refreshTokenError.response.status === 401) {
                    await router.push({name: 'login'});
                } else {
                    console.log(refreshTokenError);
                }
            }
        }
        return Promise.reject(error);
    });

    return instance;
}

