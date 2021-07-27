import axios from 'axios'
import Cookies from 'js-cookie'


//接口地址
const baseURL='http://10.3.181.32:53590'

const request = axios.create({
    
    baseURL,
    timeout: 5000,
});

// 添加请求拦截器
request.interceptors.request.use(function (config) {
     //读取token的值 设置请求头
    // 在发送请求之前做些什么  AuthorizeToken
    config.headers.AuthorizeToken=Cookies.get('token');
    return config;
}, function (error) {
    // 对请求错误做些什么
    return Promise.reject(error);
});

// 添加响应拦截器
request.interceptors.response.use(function (response) {
    // 对响应数据做点什么
    return response;
}, function (error) {
    // 对响应错误做点什么
    return Promise.reject(error);
});

export default request