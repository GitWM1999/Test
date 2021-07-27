<template>
    
 <div class="video-wrap">

    <video-player
      class="vjs-custom-skin videosa"
      :options="item"
      v-for="(item,index) in videoConfig"
      :key="index"
    ></video-player>

  </div>

</template>

<script>

export default {
  data(){
  return {
    list:[//视频源
      'http://video.keyan360.com/live/Student.m3u8',
      'http://video.keyan360.com/live/Video.m3u8'
      
    ],
    videoConfig:[]//视频配置信息
  }
},

mounted(){
 this.getVideoList();
},

methods:{
  getVideoList() {
      for (let i in this.list) {
        this.videoConfig.push({
          // playbackRates: [0.7, 1.0, 1.5, 2.0], //播放速度
          autoplay: true, //自动播放。
          controls: true, //控制条
          preload: "auto", //视频预加载
          muted: false, //默认情况下将会消除任何音频。
          loop: false, //导致视频一结束就重新开始。
          language: "zh-CN",
          aspectRatio: "16:9", // 视频比例（例如"16:9"或"4:3"）
          fluid: true, //窗体自适应
          sources: [
            {
              type: "application/x-mpegURL",
              src: this.list[i]
            }
          ],
          // poster:"", //视频封面
          // width: document.documentElement.clientWidth,
          notSupportedMessage: "此视频暂无法播放，请稍后再试"
        });
      }
    },
}
}

</script>