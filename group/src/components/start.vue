<template>
  <div>
    <div>
      <div style="float: left" class="left">
        <ul>
          <li>
            <el-button type="text" class="left-an">传媒设计</el-button>

            <a class="el-icon-caret-right"></a>
          </li>
          <li>
            <el-button type="text" class="left-an">全栈产品</el-button>

            <a class="el-icon-caret-right"></a>
          </li>
          <li>
            <el-button type="text" class="left-an">网站前端</el-button>

            <a class="el-icon-caret-right"></a>
          </li>
          <li>
            <el-button type="text" class="left-an">大数据开发</el-button>

            <a class="el-icon-caret-right"></a>
          </li>
          <li>
            <el-button type="text" class="left-an">云计算开发</el-button>

            <a class="el-icon-caret-right"></a>
          </li>
          <li>
            <el-button type="text" class="left-an">物联网开发</el-button>

            <a class="el-icon-caret-right"></a>
          </li>
        </ul>
      </div>

      <el-carousel trigger="click" height="360px" ref="carousel">
        <el-carousel-item
          v-for="item in bigScreen.images"
          :key="item.name"
          :name="item.name"
        >
          <img
            class="lubo"
            style="width: 1050px; height: 360px"
            :src="item.url"
          />
        </el-carousel-item>
      </el-carousel>

      <p style="float: left">
        <img class="bottom" src="/static/img/bottom1.png" />

        <img class="bottom1" src="/static/img/bottom2.png" />
      </p>
    </div>

    <div class="middle1">
      <h2><b>学院课程体系</b>----紧跟技术发展及企业需求</h2>

      <p>
        <img class="middle" src="/static/img/yjs.png" />

        <img class="middle" src="/static/img/dsj.png" />

        <img class="middle" src="/static/img/wlw.png" />
      </p>

      <p class="middle-bottom">
        <img class="middle" src="/static/img/wz.png" />

        <img class="middle" src="/static/img/cm.png" />

        <img class="middle" src="/static/img/qz.png" />
      </p>
    </div>

    <div class="middle2">
      <p class="title">
        <label>热门直播课</label>
      </p>

      <hr class="line" />

      <!-- <el-radio-group  style="margin-bottom: 30px">
        <el-radio-button type="text"  label="1">网站课程</el-radio-button>
        <el-radio-button type="text"  label="2">传媒课程</el-radio-button>
        <el-radio-button type="text"  label="3">全栈课程</el-radio-button>
        <el-radio-button type="text"  label="4"
          >大数据课程</el-radio-button
        >
        <el-radio-button type="text"  label="5"
          >云计算课程</el-radio-button
        >
        <el-radio-button type="text"  label="6"
          >物联网课程</el-radio-button
        >
      </el-radio-group> -->

      <el-tabs
        v-model="tabPosition"
        class="el-radio-group"
        type="card"
        @tab-click="LhandleClick"
      >
        <el-tab-pane label="全部课程" name="seven">全部课程</el-tab-pane>
        <el-tab-pane label="网站课程" name="first">网站课程</el-tab-pane>
        <el-tab-pane label="传媒课程" name="two">传媒课程</el-tab-pane>
        <el-tab-pane label="全栈课程" name="third">全栈课程</el-tab-pane>
        <el-tab-pane label="大数据课程" name="four">大数据课程</el-tab-pane>
        <el-tab-pane label="云计算课程" name="five">云计算课程</el-tab-pane>
        <el-tab-pane label="物联网课程" name="six">物联网课程</el-tab-pane>
      </el-tabs>

      <div class="likevideo">
        <div v-for="(v, i) in tableData" :key="i" class="likevideoimg">
          <img
            :src="'http://10.3.181.20:5000' + v.OutPutVideoImg"
            style="width: 319px; height: 200px"
          />

          <p class="likevideop">
            {{ v.OutPutCourseDescription }}
          </p>

          <p class="likevideoper">已有1234人学习</p>

          <p class="likevideoprice">
            <span style="color: red" v-if="v.OutPutCoursePrice === 0"
              >免费</span
            >

            <span style="color: red" v-if="v.OutPutCoursePrice != 0"
              >￥{{ v.OutPutCoursePrice }}</span
            >

            <span @click="videocollect(v.OutPutVideoId)">
              <i
                id="sc"
                v-if="v.OutPutVideoCollect === 0"
                class="el-icon-star-off"
                >收藏</i
              >
              <i
                id="sc"
                v-if="v.OutPutVideoCollect === 1"
                class="el-icon-star-off"
                >已收藏</i
              >
            </span>
          </p>
        </div>
      </div>
    </div>

    <div class="middle3">
      <p class="title">
        <label>热门录播课</label>
      </p>

      <hr class="line" />

      <!-- <el-radio-group v-model="activeName"  style="margin-bottom: 30px">
        <el-radio-button type="text"  label="网站课程">网站课程</el-radio-button>
        <el-radio-button type="text"  label="传媒课程">传媒课程</el-radio-button>
        <el-radio-button type="text"  label="全栈课程">全栈课程</el-radio-button>
        <el-radio-button type="text"  label="大数据课程"
          >大数据课程</el-radio-button
        >
        <el-radio-button type="text"  label="云计算课程"
          >云计算课程</el-radio-button
        >
        <el-radio-button type="text"  label="物联网课程"
          >物联网课程</el-radio-button
        >
      </el-radio-group> -->

      <el-tabs
        v-model="activeName"
        class="el-radio-group"
        type="card"
        @tab-click="handleClick"
      >
        <el-tab-pane label="全部课程" name="seven">全部课程</el-tab-pane>
        <el-tab-pane label="网站课程" name="first">网站课程</el-tab-pane>
        <el-tab-pane label="传媒课程" name="two">传媒课程</el-tab-pane>
        <el-tab-pane label="全栈课程" name="third">全栈课程</el-tab-pane>
        <el-tab-pane label="大数据课程" name="four">大数据课程</el-tab-pane>
        <el-tab-pane label="云计算课程" name="five">云计算课程</el-tab-pane>
        <el-tab-pane label="物联网课程" name="six">物联网课程</el-tab-pane>
      </el-tabs>

      <div class="likevideo">
        <div v-for="(v, i) in LtableData" :key="i" class="likevideoimg">
          <img
            :src="'http://10.3.181.20:5000' + v.Class_Img"
            style="width: 319px; height: 200px"
          />

          <p class="likevideop">
            {{ v.Class_Name }}
          </p>

          <p class="likevideoper">已有1234人学习</p>

          <p class="likevideoprice">
            <span style="color: red" v-if="v.Class_Price === 0">免费</span>

            <span style="color: red" v-if="v.Class_Price != 0"
              >￥{{ v.Class_Price }}</span
            >

            <span @click="classcollect(v.Class_Id)">
              <i id="sc" v-if="v.Class_Collect === 0" class="el-icon-star-off"
                >收藏</i
              >
              <i id="sc" v-if="v.Class_Collect === 1" class="el-icon-star-off"
                >已收藏</i
              >
            </span>
          </p>
        </div>
      </div>
    </div>

    <div class="middle4">
      <p class="title">
        <label>限时秒杀课</label>
      </p>

      <hr class="line" />

      <span style="margin-left: -1320px">距离秒杀开始:</span>

      <div class="ms">
        <van-count-down class="mstime" :time="time"></van-count-down>
      </div>

      <div class="likevideo">
        <div v-for="(v, i) in StableData" :key="i" class="likevideoimg">
          <img
            :src="'http://10.3.181.20:5000' + v.Class_Img"
            style="width: 319px; height: 200px"
          />

          <p class="likevideop">
            {{ v.Class_Name }}
          </p>

          <p class="likevideoper">已有1234人学习</p>

          <p class="likevideoprice">
            <span style="color: red" v-if="v.Class_SalePrice === 0">免费</span>

            <span style="color: red" v-if="v.Class_SalePrice != 0"
              >￥{{ v.Class_SalePrice }}</span
            >

            <span @click="classcollect(v.Class_Id)">
              <i id="sc" v-if="v.Class_Collect === 0" class="el-icon-star-off"
                >收藏</i
              >
              <i id="sc" v-if="v.Class_Collect === 1" class="el-icon-star-off"
                >已收藏</i
              >
            </span>
          </p>
        </div>
      </div>
    </div>

    <div class="bottomfoot">
      <p class="bottomp">
        <el-button class="bottomazo" type="text">关于我们</el-button>
        <el-button class="bottomazo" type="text">联系我们</el-button>
        <el-button class="bottomazo" type="text">讲师招募</el-button>
        <el-button class="bottomazo" type="text">帮助中心</el-button>
        <el-button class="bottomazo" type="text">意见反馈</el-button>
        <el-button class="bottomazo" type="text">就业服务</el-button>
      </p>

      <p class="bottomp">
        <el-button class="bottomaz" type="text">邮箱：100193</el-button>
        <el-button class="bottomaz" type="text">电话：400-008-0897</el-button>
        <el-button class="bottomaz" type="text"
          >业务及合作：bjebin@163.com</el-button
        >
      </p>
      <p class="bottomp">
        <el-button class="bottomazed" type="text">八维教育</el-button>
        <el-button class="bottomazed" type="text"
          >京公网备案1101185263855</el-button
        >
      </p>

      <div class="bottom-right1">
        <ul>
          <li>
            <el-button icon="el-icon-star-off" circle></el-button>
          </li>
          <li class="text" style="color: white">收藏本站</li>
        </ul>
      </div>

      <div class="bottom-right2">
        <ul>
          <li>
            <el-button icon="el-icon-user" circle></el-button>
          </li>
          <li class="text" style="color: white">微信公众号</li>
        </ul>
      </div>
    </div>
  </div>
</template>




<script>
import Vue from "vue";

import { Swipe, SwipeItem } from "vant";

Vue.use(Swipe);

Vue.use(SwipeItem);

import { CountDown } from "vant";

Vue.use(CountDown);

import { Icon } from "vant";

Vue.use(Icon);

 //引入插件
import axios from "axios";

export default {
  name: "start",
  data() {
    return {
      tableData: [],
      LtableData: [],
      StableData: [],
      OutPutCourseDescription: "",
      OutPutCoursePrice: 0,
      OutPutVideoImg: "",
      Class_Name: "",
      Class_Price: 0,
      Class_Img: "",
      Class_SalePrice: 0,
      tabPosition: "",
      activeName: "",
      Class_Collect: 0,
      VideoCollect: 0,
      Class_Id: 0,
      OutPutVideoId: 0,
      class_ClassType: 0,
      bigScreen: {
        images: [
          {
            name: "bigScreen01",
            url: "static/img/lubo1.png",
          },
          {
            name: "bigScreen02",
            url: "static/img/lubo2.jpeg",
          },
          {
            name: "bigScreen03",
            url: "static/img/lubo3.jpeg",
          },
          {
            name: "bigScreen04",
            url: "static/img/lubo4.jpeg",
          },
        ],
      },
      time: 30 * 60 * 60 * 100,
    };
  },
  mounted() {
    this.getList();
    this.LgetList();
    this.SgetList();
  },
  methods: {
    handleClick(tab, event) {
      console.log(tab, event);
    },
    //显示方法
    getList() {
      this.$axios
        .get(
          "http://10.3.181.20:5000/GetVideo?class_ClassType=" +
            this.class_ClassType
        )
        .then((res) => {
          //赋值
          this.tableData = res.data.Data;
        });
    },
    //显示方法
    LgetList() {
      this.$axios
        .get(
          "http://10.3.181.20:5000/GetLVideo?class_ClassType=" +
            this.class_ClassType
        )
        .then((res) => {
          //赋值
          this.OutPutVideoId = res.data.OutPutVideoId;
          this.LtableData = res.data.Data;
        });
    },
    //显示方法
    SgetList() {
      this.$axios.get("http://10.3.181.20:5000/GetSVideo").then((res) => {
        //赋值
        this.StableData = res.data.Data;
      });
    },
    videocollect(videoid) {

      axios({
          url: "http://10.3.181.20:5000/GetVideoCollect",
          method: "put",
          params:{
             VideoId:videoid
          }
        }).then((res) => {

          if (res.data.Data > 0) {
            
            this.$message({
            type: "success",
            message: "收藏成功！可在我的收藏中查看",
          });
            
          this.getList();
          } 
          
        });

      
    },
    classcollect(Classid) {

        axios({
          url: "http://10.3.181.20:5000/GetCollect",
          method: "put",
          params:{
             Class_Id:Classid
          }
        }).then((res) => {

          if (res.data.Data > 0) {
            
            this.$message({
            type: "success",
            message: "收藏成功！可在我的收藏中查看",
          });
            
          this.LgetList();
          this.SgetList();
          } 
          
        });


    },
    handleClick(tab, event) {
      var val = this.activeName;
      if (val == "first") {
        //全部
        this.class_ClassType = "1";
        this.LgetList();
      }
      if (val == "two") {
        //待付款
        this.class_ClassType = "2";
        this.LgetList();
      }
      if (val == "third") {
        //代发货
        this.class_ClassType = "3";
        this.LgetList();
      }
      if (val == "four") {
        //已发货
        this.class_ClassType = "4";
        this.LgetList();
      }
      if (val == "five") {
        //已完成
        this.class_ClassType = "5";
        this.LgetList();
      }
      if (val == "six") {
        //退款中
        this.class_ClassType = "6";
        this.LgetList();
      }
      if (val == "seven") {
        //退款中
        this.class_ClassType = "0";
        this.LgetList();
      }
    },
    LhandleClick(tab, event) {
      var val = this.tabPosition;
      if (val == "first") {
        //全部
        this.class_ClassType = "1";
        this.getList();
      }
      if (val == "two") {
        //待付款
        this.class_ClassType = "2";
        this.getList();
      }
      if (val == "third") {
        //代发货
        this.class_ClassType = "3";
        this.getList();
      }
      if (val == "four") {
        //已发货
        this.class_ClassType = "4";
        this.getList();
      }
      if (val == "five") {
        //已完成
        this.class_ClassType = "5";
        this.getList();
      }
      if (val == "six") {
        //退款中
        this.class_ClassType = "6";
        this.getList();
      }
      if (val == "seven") {
        //退款中
        this.class_ClassType = "0";
        this.getList();
      }
    },
  },
};
</script>

<style>
.lubo {
  margin-left: -300px;
}
.left {
  width: 200px;
  height: 360px;
  line-height: 50px;
  background-color: darkslateblue;
  margin-left: 139px;
}

li {
  list-style: none;
  margin-left: -27px;
  line-height: 50px;
}
a {
  color: white;
}
.left-an {
  margin-top: 15px;
  color: white;
}
.bottom {
  width: 600px;
  height: 120px;
  margin-left: 137px;
  margin-top: 20px;
}
.bottom1 {
  width: 600px;
  height: 120px;
  margin-left: 50px;
  margin-top: 20px;
}
.middle1 {
  margin-top: 190px;
  margin-left: -218px;
}
.middle {
  width: 380px;
  height: 180px;
  margin-left: 50px;
}
.middle-bottom {
  margin-top: 25px;
}
label {
  font-size: 20px;
  margin-left: 50px;
}
.title {
  margin-top: 30px;
  margin-left: -1373px;
}
.line {
  border-bottom: 1px solid black;
  width: 100px;
  margin-left: 130px;
  margin-top: 10px;
}

.likevideo {
  width: 1600px;
  height: 680px;
}
.likevideoimg {
  width: 319px;
  height: 320px;
  margin-left: 130px;
  border-radius: 4px;
  box-shadow: 0 0 2px 2px whitesmoke;
  float: left;
}
.likevideop {
  margin-top: 15px;
}
.mstime {
  margin-left: -1380px;
  color: white;
}
#sc {
  margin-left: 190px;
}
.ms {
  margin-left: 130px;
  height: 20px;

  background-color: red;
}
.bottomfoot {
  width: 100%;
  height: 180px;
  background-color: black;
}
.bottomp {
  line-height: 30px;
  width: 643px;
}
.bottomaz {
  color: white;
  margin-top: 10px;
  margin-left: -35px;
}
.bottom-right1 {
  width: 120px;
  height: 90px;
  margin-top: -130px;
  margin-left: 1200px;
}
.bottom-right2 {
  width: 130px;
  height: 90px;
  margin-top: -90px;
  margin-left: 1300px;
}
.text {
  margin-left: -25px;
}
.el-radio-group {
  margin-left: -710px;
}
.likevideoper {
  margin-left: -218px;
}
.likevideoprice {
  margin-left: -30px;
  margin-top: 20px;
}
.bottomazed {
  margin-left: -240px;
  color: white;
  margin-top: 10px;
}
.bottomazo {
  margin-left: -50px;
  color: white;
  margin-top: 10px;
}
</style>
