<template>

<div>

<div class="head">

    <label class="head-title">直播标题</label>

    <p class="head-title">
        <label>直播人：杰哥</label>
        <label class="time">时间：{{ nowDate }}</label>
        <el-button class="exit" type="danger" style="width:120px;float:right" round>退出直播间</el-button>
    </p>
    

</div>

 <div class="bottom">

   <p>
       <span style="color:white">主持人可见</span>

       <el-switch
        v-model="value"
        active-color="#13ce66"
        inactive-color="#ff4949">
       </el-switch>

   </p>
   
  <div class="right">

   <label class="title">聊天</label>
   
   <hr class="line" />

   <el-input class="socket" placeholder="说点什么"></el-input><el-button type="primary">发送</el-button>

   <p>
    
    <span class="like" @click="idea">&#10084;</span>
 
    <span style="color:red;font-size:22px">{{this.ideanum}}</span>


   
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
      ideanum:0,
    };
  },
  
  methods: {
    currentTime() {
      setInterval(this.formatDate, 500);
    },
    formatDate() {
      let date = new Date();
      let year = date.getFullYear(); // 年
      let month = date.getMonth() + 1; // 月
      let day = date.getDate(); // 日
      let week = date.getDay(); // 星期
      let weekArr = [ "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" ];
      let hour = date.getHours(); // 时
      hour = hour < 10 ? "0" + hour : hour; // 如果只有一位，则前面补零
      let minute = date.getMinutes(); // 分
      minute = minute < 10 ? "0" + minute : minute; // 如果只有一位，则前面补零
      let second = date.getSeconds(); // 秒
      second = second < 10 ? "0" + second : second; // 如果只有一位，则前面补零
      this.nowDate = `${year}/${month}/${day} ${hour}:${minute}:${second} ${weekArr[week]}`;
    },
    idea(){
      
       this.ideanum++;
       
    }
  },
  mounted() {
    this.currentTime();
  },
  // 销毁定时器
  beforeDestroy() {
    if (this.formatDate) {
      clearInterval(this.formatDate); // 在Vue实例销毁前，清除时间定时器
    }
  }
};
//鼠标
 !function (e, t, a) {function r() {for (var e = 0; e < s.length; e++) s[e].alpha <= 0 ? (t.body.removeChild(s[e].el), s.splice(e, 1)) : (s[e].y--, s[e].scale += .004, s[e].alpha -= .013, s[e].el.style.cssText = "left:" + s[e].x + "px;top:" + s[e].y + "px;opacity:" + s[e].alpha + ";transform:scale(" + s[e].scale + "," + s[e].scale + ") rotate(45deg);background:" + s[e].color + ";z-index:99999");requestAnimationFrame(r)}function n() {var t = "function" == typeof e.onclick && e.onclick;e.onclick = function (e) {t && t(), o(e)}}function o(e) {var a = t.createElement("div");a.className = "heart", s.push({el: a,x: e.clientX - 5,y: e.clientY - 5,scale: 1,alpha: 1,color: c()}), t.body.appendChild(a)}function i(e) {var a = t.createElement("style");a.type = "text/css";try {a.appendChild(t.createTextNode(e))} catch (t) {a.styleSheet.cssText = e}t.getElementsByTagName("head")[0].appendChild(a)}function c() {return "rgb(" + ~~(255 * Math.random()) + "," + ~~(255 * Math.random()) + "," + ~~(255 * Math.random()) + ")"}var s = [];e.requestAnimationFrame = e.requestAnimationFrame || e.webkitRequestAnimationFrame || e.mozRequestAnimationFrame || e.oRequestAnimationFrame || e.msRequestAnimationFrame || function (e) {setTimeout(e, 1e3 / 60)}, i(".heart{width: 10px;height: 10px;position: fixed;background: #f00;transform: rotate(45deg);-webkit-transform: rotate(45deg);-moz-transform: rotate(45deg);}.heart:after,.heart:before{content: '';width: inherit;height: inherit;background: inherit;border-radius: 50%;-webkit-border-radius: 50%;-moz-border-radius: 50%;position: fixed;}.heart:after{top: -5px;}.heart:before{left: -5px;}"), n(), r()}(window, document);
</script>

<style>
*{
	margin: 0;
	padding: 0;
}
.head{

    width: 1000px;
    height: 100px;
    background-color:whitesmoke;
    line-height: 30px;
    margin-left: 30px;
}

.head-title{
    
   margin-top: 10px;
   
}
.time{
    margin-left: 40px;
}
.exit{
    margin-top: -10px;
}
.bottom{
    width: 700px;
    height: 500px;
    background-color:skyblue;
    margin-left: 30px;
}
.middle{
    width: 600px;
    height: 360px;
    background-color: white;
    
}
.right{
    width: 300px;
    height: 500px;
    background-color: black;
    margin-left: 700px;
    margin-top: -30px;
}
.title{
    margin-top: 50px;
    color: white;
    margin-left: 10px;
}
.line{
     border-bottom:1px solid white;
     width: 100px;
     margin-top: 10px;
     border-color: orange;
     margin-left: 10px;
}
.socket{
    width: 200px;
    height: 30px;
    background-color: whitesmoke;
    margin-top: 290px;
    margin-left: 5px;
}
.like{
 font-size:40px;
 color:red; 
 cursor:pointer;
 margin-left: 180px;
 width: 50px;
}

</style>

