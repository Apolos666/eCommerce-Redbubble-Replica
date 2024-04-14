import axios from "axios";

export default (url='http://localhost:5258/api') => {
    return axios.create({
        baseURL: url,
    })
}