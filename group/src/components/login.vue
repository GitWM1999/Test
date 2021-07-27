<template>

<div>

<div class="deng">
     
     <div class="box1">
     
      <img class="fengmian" src="/static/img/login.png" />

      <div class="box2">

       <el-button type="primary" class="way" style="width:100px">账号注册</el-button>
       <el-button type="primary" class="way" style="width:130px">人脸识别注册</el-button>

       <h3><b>八维在线教育</b></h3>

       <i class="el-icon-user" style="margin-left:60px;margin-top:30px"></i>
       <el-input style="width:180px" placeholder="请输入手机号"></el-input>

       <i class="el-icon-lock" style="margin-left:60px;margin-top:30px"></i>
       <el-input style="width:180px" type="pass" placeholder="请输入密码"></el-input>

       <el-button style="margin-left:50px;margin-top:20px" type="text">忘记密码？</el-button>

       <el-button type="text">没有账号，点我注册</el-button>

        <el-button type="primary" style="width:220px;margin-left:55px;margin-top:10px" round>登录</el-button>

      </div>

     </div>
    
    </div>

</div>
</template>

<script>
export default {
  name: "login"
}
</script>

<style>
*{
	margin: 0;
	padding: 0;
}
.deng{
	position: absolute;
	width: 100%;
	height: 600px;
	background-color: #188eee;
  margin-top: 20px;
}	
.box1{
    width: 600px;
    height: 400px;
    background-color: whitesmoke;
    margin-top: 100px;
    margin-left: 480px;
}
.fengmian{
    width: 280px;
    height: 400px;
    
}
.way{
    margin-top: 15px;
    margin-left: 40px;
}
.box2{
    width: 320px;
    float:right;
}
h3{
    margin-left: 50px;
}
</style>