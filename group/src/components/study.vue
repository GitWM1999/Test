

<template>
  <div class="player-container">
    <video-player class="vjs-custom-skin" :options="playerOptions"></video-player>
  </div>
</template>

<script>
  //引入video样式
  import 'video.js/dist/video-js.css'
  import 'vue-video-player/src/custom-theme.css'

  //引入hls.js
  import 'videojs-contrib-hls.js/src/videojs.hlsjs'

  export default {
    name:'HelloWorld',
    data () {
      return {
        playerOptions: {
          playbackRates: [0.7, 1.0, 1.5, 2.0], //播放速度
          autoplay: false, //如果true,浏览器准备好时开始回放。
          controls: true, //控制条
          preload: 'auto', //视频预加载
          muted: false, //默认情况下将会消除任何音频。
          loop: false, //导致视频一结束就重新开始。
          language: 'zh-CN',
          aspectRatio: '16:9', // 将播放器置于流畅模式，并在计算播放器的动态大小时使用该值。值应该代表一个比例 - 用冒号分隔的两个数字（例如"16:9"或"4:3"）
          fluid: true, // 当true时，Video.js player将拥有流体大小。换句话说，它将按比例缩放以适应其容器。
          sources: [{
            src: 'http://1305739671.vod2.myqcloud.com/ebfb1bf4vodtranscq1305739671/912ac0973701925921231317361/v.f100010.mp4',//播放地址
            type: 'video/mp4'
          }],
          poster: "http://1305739671.vod2.myqcloud.com/15112e4cvodcq1305739671/912ac0973701925921231317361/3701925921231459885.jpeg", //你的封面地址
          width: document.documentElement.clientWidth,
          notSupportedMessage: '此视频暂无法播放，请稍后再试' //允许覆盖Video.js无法播放媒体源时显示的默认信息。
        }
      }
    },
    
  }
</script>



<!--<template>
    <div>
        <p><i class="el-icon-time"></i> {{ `${hr}: ${min}: ${sec}` }}</p>
        <el-button v-show="isshow1" @click="begin" round type="primary">开始答题</el-button>
        <el-button v-show="!isshow1" @click="open" round type="danger">交卷</el-button>
    </div>
</template>


<script>

import { time } from 'echarts';

    // 需引入elementUI配合提示，或者自行制作
    export default {
        data() {
            return {
                isshow1: true,
                time: '',
                hr: 0,
                min: 1,
                sec: 0,
            }
        },
        methods: {
            begin() {
                // 点击按钮后开始计算指定长度的时间
                this.time = (Date.parse(new Date()) + ((0.001 * 60 *60)) * 1000);
                // 开始执行倒计时
                this.countdown();
                // 更换按钮，根据情况选择v-if或v-show
                this.isshow1 = false;

                this.$message({
                    type: 'success',
                    message: '开始答题'
                });
            },
            countdown() {
                const end = this.time; // 定义结束时间
                const now = Date.parse(new Date()); // 获取本地时间
                const msec = end - now; // 定义总共所需的时间
                // 将时间戳进行格式化
                let hr = parseInt(msec / 1000 / 60 / 60 % 24);
                let min = parseInt(msec / 1000 / 60 % 60);
                let sec = parseInt(msec / 1000 % 60);
                // 倒计时结束时的操作
                const that = this;
                if (this.hr == 0 && this.min == 0 && this.sec == 0) {

                    this.hr = 0;
                    this.min = 0;
                    this.sec = 0;

                     this.$message({
                        type: 'success',
                        message: '时间已经结束，正在交卷中！'

                    });
                    
                    this.timer = setTimeout(()=>{   //设置延迟执行
                     alert("交卷成功！")
                    },2000);
                    
                } else {
                    // 如时间未归零则继续在一秒后执行
                    this.hr = hr > 9 ? hr : '0' + hr;
                    this.min = min > 9 ? min : '0' + min;
                    this.sec = sec > 9 ? sec : '0' + sec;
                    setTimeout(that.countdown, 1000)
                }
            },
            open() {
                this.$confirm('即将结束答题, 是否继续?', '提示', {
                    confirmButtonText: '确定',
                    cancelButtonText: '取消',
                    type: 'warning'
                }).then((action) => {
                    // eleUI的确定结束回调函数方法
                    if (action === 'confirm') {
                        this.hr = 0;
                        this.min = 0;
                        this.sec = 0;
                        console.log(this.hr + ',' + this.min + ',' + this.sec);
                        this.isshow1 = true;
                    }
                    this.$message({
                        type: 'success',
                        message: '交卷成功!'
                    });
                }).catch(() => {
                    // 点击取消后
                    this.$message({
                        type: 'info',
                        message: '已取消交卷'
                    });
                });

            }
        }
    }
</script>




