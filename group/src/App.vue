<template>

  <div id="app">
<!--    <img src="./assets/logo.png">-->
    <!--    <HelloWorld/>-->
<!--    <MyComponent></MyComponent>-->
<p class="mainp">

<router-link class="ai" to="/start">八维教育首页</router-link>

<router-link class="ai" to="/freeclass">免费课程</router-link>

<router-link class="ai" to="/systemclass">体系课程</router-link>

<router-link class="ai" to="/evaluation">在线测评</router-link>

<router-link class="ai" to="/study">学习社区</router-link>

<el-input class="query" placeholder="请输入关键字"></el-input>

<router-link class="ai" to="/collect">我的收藏</router-link>

 <router-link class="ai" to="/shopcar">
 <i class="el-icon-shopping-cart-full"></i>
 </router-link>

<router-link class="ai" to="/login">登录</router-link>

<router-link class="ai" to="/register">注册</router-link>

</p>

<router-view></router-view>

</div>

</template>

<script>

import login from "./components/login";
import freeclass from "./components/freeclass";
import study from "./components/study";
import collect from "./components/collect";

export default {
  name: 'App',
  name:'freeclass',
  name:'study',
  name:'collect',
  components: {
    // HelloWorld
    login,
    freeclass,
    study,
    collect
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.query{
    margin-left: 30px;
    width: 240px;
    height: 42px;
    margin-top: -5px;
    border: 1px black solid;
}
.ai{
   font-size: 21px;
   color: black;
   margin-left: 50px;
}
.mainp{
  margin-left: 80px;
  width: 1450px;
}
</style>
