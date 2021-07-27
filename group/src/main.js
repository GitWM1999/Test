// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import '../static/bootstrap/css/bootstrap.css'
import axios  from 'axios'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';

import { Swipe, SwipeItem } from 'vant';

Vue.use(Swipe);
Vue.use(SwipeItem);

/* 视频监控插件 */
import VueVideoPlayer from 'vue-video-player'
import 'video.js/dist/video-js.css'
import 'videojs-contrib-hls' //引入才能播放m3u8文件

Vue.use(VueVideoPlayer)

// 生成签名插件 
import vueEsign from 'vue-esign'
Vue.use(vueEsign)

import VueQuillEditor from 'vue-quill-editor';
import 'quill/dist/quill.core.css'
import 'quill/dist/quill.snow.css'
import 'quill/dist/quill.bubble.css'


import Video from 'video.js'
Vue.prototype.$video = Video


Vue.use (axios);
Vue.prototype.$http = axios;
Vue.config.productionTip = false;
Vue.use(ElementUI);
Vue.use(VueQuillEditor);
Vue.prototype.bus=new Vue();


new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})
