<template>
  <div>
    <div class="head">
      <label class="head-title">直播标题</label>

      <p class="head-title">
        <label>直播人：杰哥</label>
        <label class="time">时间：{{ nowDate }}</label>
        <el-button
          class="exit"
          type="danger"
          style="width: 120px; float: right"
          round
          >退出直播间</el-button
        >
      </p>
    </div>

    <div class="bottom">
      <p style="float: left; margin-top: 8px; font-size: 18px">
        <el-button v-model="first" type="primary" @click="white" label="白板"
          >白板</el-button
        >

        <el-button type="danger" @click="question = true" label="添加问卷"
          >添加问卷</el-button
        >

        <el-dialog
          title="添加问卷（最多只能有5个问卷题目）"
          :visible.sync="question"
          width="30%"
        >
          <el-col :span="24" class="warp-main">
            <el-form
              :inline="true"
              class="demo-form-inline"
              v-for="(item, index) in formArr"
              :key="index"
            >
              <el-form-item label="问卷题目">
                <el-input v-model="item.title"></el-input>
              </el-form-item>
            </el-form>
          </el-col>

          <span slot="footer" class="dialog-footer">
            <el-button v-model="number" @click="add">添加</el-button>
            <el-button type="primary" @click="goquestion">发布问卷</el-button>
          </span>
        </el-dialog>
      </p>

      <div class="canves">
        <el-button @click="square" style="margin-top: 5px" label="矩形工具"
          >矩形工具</el-button
        >

        <el-button style="margin-top: 5px" @click="back" label="橡皮擦"
          >橡皮擦</el-button
        >
        <el-button style="margin-top: 5px" @click="clear" label="清空"
          >清空</el-button
        >
        <el-button style="margin-top: 5px" @click="save" label="保存"
          >保存</el-button
        >

        <vue-esign
          id="canvas"
          v-if="first === 1"
          style="border: 1px solid #000"
          ref="esign"
          :width="600"
          :height="400"
          :isCrop="isCrop"
          :lineWidth="lineWidth"
          :lineColor="lineColor"
          :bgColor.sync="bgColor"
        />
      </div>

      <div class="video-wrap">
        <video-player
          class="vjs-custom-skin videosa"
          :options="item"
          v-for="(item, index) in videoConfig"
          :key="index"
          style="width: 550px; height: 400px"
        ></video-player>
      </div>

      <div class="right">
        <div class="video-wrap">
          <video-player
            class="vjs-custom-skin videosa"
            :options="item"
            v-for="(item, index) in video"
            :key="index"
            style="width: 240px; height: 10px"
          ></video-player>
        </div>

        <label class="title">聊天</label>

        <hr class="line" />

        <el-input class="socket" placeholder="跟老师聊点什么"></el-input
        ><el-button type="primary">发送</el-button>

        <p>
          <span class="like" @click="idea">&#10084;</span>

          <span style="color: red; font-size: 22px">{{ this.ideanum }}</span>
        </p>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  data() {
    return {
      nowDate: "", // 当前日期
      value: true,
      ideanum: 0,
      tabPosition: "left",
      lineWidth: 6,
      lineColor: "#000000",
      bgColor: "",
      resultImg: "",
      isCrop: false,
      first: 0,
      num: 0,
      question: false,
      title: "",
      number: 0,
      xpc: 0,
      formArr: [
        {
          title: "",
        },
      ],
      Data: [],
      list: [
        //视频源

        "http://video.keyan360.com/live/Video.m3u8",
      ],
      videoConfig: [], //视频配置信息
      Slist: [
        //视频源

        "http://video.keyan360.com/live/Student.m3u8",
      ],
      video: [], //视频配置信息
    };
  },

  methods: {
    currentTime() {
      setInterval(this.formatDate, 500);
    },
    clear() {
      this.$refs.esign.reset();
    },
    save() {
      this.$refs.esign
        .generate()
        .then((res) => {
          this.resultImg = res;
          console.log(res);
        })
        .catch((err) => {
          alert(err);
        });
    },
    white() {
      this.first = 1;

      this.num++;

      if (this.num % 2 == 0) {
        this.first = 0;
      }
    },
    back() {
      this.xpc++;

      if (this.xpc % 2 != 0) {
        this.lineColor = "skyblue";
      }

      if (this.xpc % 2 == 0) {
        this.lineColor = "#000000";
      }
    },
    square() {
      var c = document.getElementById("canvas");
      var ctx = c.getContext("2d");
      ctx.fillStyle = "white";
      ctx.fillRect(20, 20, 150, 100);
    },
    add() {
      this.formArr.push({});

      this.number++;

      if (this.number >= 5) {
        this.$message({
          type: "success",
          message: "问卷题目已达最大数，无法添加",
        });

        this.formArr.pop({});
      }
    },
    goquestion() {

      for (let i = 0; i < this.formArr.length; i++) {
        
        alert(this.formArr[i].title);

        this.Data = this.formArr[i].title;
      }
    },
    formatDate() {
      let date = new Date();
      let year = date.getFullYear(); // 年
      let month = date.getMonth() + 1; // 月
      let day = date.getDate(); // 日
      let week = date.getDay(); // 星期
      let weekArr = [
        "星期日",
        "星期一",
        "星期二",
        "星期三",
        "星期四",
        "星期五",
        "星期六",
      ];
      let hour = date.getHours(); // 时
      hour = hour < 10 ? "0" + hour : hour; // 如果只有一位，则前面补零
      let minute = date.getMinutes(); // 分
      minute = minute < 10 ? "0" + minute : minute; // 如果只有一位，则前面补零
      let second = date.getSeconds(); // 秒
      second = second < 10 ? "0" + second : second; // 如果只有一位，则前面补零
      this.nowDate = `${year}/${month}/${day} ${hour}:${minute}:${second} ${weekArr[week]}`;
    },
    idea() {
      this.ideanum++;
    },
    //讲师直播
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
              src: this.list[i],
            },
          ],
          // poster:"", //视频封面
          // width: document.documentElement.clientWidth,
          notSupportedMessage: "此视频暂无法播放，请稍后再试",
        });
      }
    },
    //学生直播
    getSVideoList() {
      for (let i in this.Slist) {
        this.video.push({
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
              src: this.Slist[i],
            },
          ],
          // poster:"", //视频封面
          // width: document.documentElement.clientWidth,
          notSupportedMessage: "此视频暂无法播放，请稍后再试",
        });
      }
    },
  },
  mounted() {
    this.currentTime();
    this.getVideoList();
    this.getSVideoList();
  },
  // 销毁定时器
  beforeDestroy() {
    if (this.formatDate) {
      clearInterval(this.formatDate); // 在Vue实例销毁前，清除时间定时器
    }
  },
};
//鼠标
!(function (e, t, a) {
  function r() {
    for (var e = 0; e < s.length; e++)
      s[e].alpha <= 0
        ? (t.body.removeChild(s[e].el), s.splice(e, 1))
        : (s[e].y--,
          (s[e].scale += 0.004),
          (s[e].alpha -= 0.013),
          (s[e].el.style.cssText =
            "left:" +
            s[e].x +
            "px;top:" +
            s[e].y +
            "px;opacity:" +
            s[e].alpha +
            ";transform:scale(" +
            s[e].scale +
            "," +
            s[e].scale +
            ") rotate(45deg);background:" +
            s[e].color +
            ";z-index:99999"));
    requestAnimationFrame(r);
  }
  function n() {
    var t = "function" == typeof e.onclick && e.onclick;
    e.onclick = function (e) {
      t && t(), o(e);
    };
  }
  function o(e) {
    var a = t.createElement("div");
    (a.className = "heart"),
      s.push({
        el: a,
        x: e.clientX - 5,
        y: e.clientY - 5,
        scale: 1,
        alpha: 1,
        color: c(),
      }),
      t.body.appendChild(a);
  }
  function i(e) {
    var a = t.createElement("style");
    a.type = "text/css";
    try {
      a.appendChild(t.createTextNode(e));
    } catch (t) {
      a.styleSheet.cssText = e;
    }
    t.getElementsByTagName("head")[0].appendChild(a);
  }
  function c() {
    return (
      "rgb(" +
      ~~(255 * Math.random()) +
      "," +
      ~~(255 * Math.random()) +
      "," +
      ~~(255 * Math.random()) +
      ")"
    );
  }
  var s = [];
  (e.requestAnimationFrame =
    e.requestAnimationFrame ||
    e.webkitRequestAnimationFrame ||
    e.mozRequestAnimationFrame ||
    e.oRequestAnimationFrame ||
    e.msRequestAnimationFrame ||
    function (e) {
      setTimeout(e, 1e3 / 60);
    }),
    i(
      ".heart{width: 10px;height: 10px;position: fixed;background: #f00;transform: rotate(45deg);-webkit-transform: rotate(45deg);-moz-transform: rotate(45deg);}.heart:after,.heart:before{content: '';width: inherit;height: inherit;background: inherit;border-radius: 50%;-webkit-border-radius: 50%;-moz-border-radius: 50%;position: fixed;}.heart:after{top: -5px;}.heart:before{left: -5px;}"
    ),
    n(),
    r();
})(window, document);
</script>

<style>
* {
  margin: 0;
  padding: 0;
}
.head {
  width: 1000px;
  height: 100px;
  background-color: whitesmoke;
  line-height: 30px;
  margin-left: 30px;
}

.head-title {
  margin-top: 10px;
}
.time {
  margin-left: 40px;
}
.exit {
  margin-top: -10px;
}
.bottom {
  width: 700px;
  height: 600px;
  background-color: skyblue;
  margin-left: 30px;
}
.middle {
  width: 600px;
  height: 360px;
  background-color: white;
}
.right {
  width: 400px;
  height: 600px;
  background-color: black;
  margin-left: 700px;
  margin-top: -650px;
}
.title {
  margin-top: 150px;
  color: white;
  margin-left: -280px;
}
.vjs-custom-skin {
  margin-left: 100px;
  margin-top: 100px;
}
.vjs-custom {
  margin-top: -50px;
}
.line {
  border-bottom: 1px solid white;
  width: 100px;
  margin-top: 10px;
  border-color: orange;
  margin-left: 10px;
}
.socket {
  width: 300px;
  height: 30px;
  background-color: whitesmoke;
  margin-top: 290px;
  margin-left: 5px;
}
.like {
  font-size: 40px;
  color: red;
  cursor: pointer;
  margin-left: 260px;
  width: 50px;
}
.canves {
  width: 450px;
  height: 50px;
  background-color: black;
  margin-left: 230px;
}
</style>

