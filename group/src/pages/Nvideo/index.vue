<template>
    
<div>
   <img class="wzm" src="/static/img/wzm.png" />

   <div class="right">
       
       <h4>距离直播开始还有</h4>

       <div class="time">
        <ul>
            <li class="tn">00</li>
            <li class="cn">天</li>
        </ul>
       </div>

        <div class="time">
         <ul>
            <li class="tn">00</li>
            <li class="cn">小时</li>
        </ul>
       </div>

        <div class="time">
        <ul>
            <li class="tn">00</li>
            <li class="cn">分钟</li>
        </ul>
       </div>

        <div class="time">
         <ul>
            <li class="tn">55</li>
            <li class="cn">秒</li>
        </ul>
       </div>

    <p class="person">
    <span style="color:red">{{num}}</span>
    人预约
    </p>

    <el-button type="danger" style="width:170px;margin-left:15px;margin-top:50px" round>已预约</el-button>
 
    <p style="color:gray;margin-left:83px;margin-top:20px">免费</p>
   </div>

</div>

</template>

<script>
export default {
  data() {
    return {
      num:5
    };
  }
}
</script>


<style>

  .wzm{
      width: 600px;
      height: 400px;
      margin-left: 50px;
      float: left;
  }
  .right{
      width: 200px;
      height: 400px;
      background-color: black;
      float: left;
      
  }
  h4{
      color: white;
      margin-left: 25px;
      margin-top: 30px;
  }
.time{
    width: 40px;
    height: 80px;
    border: 1px solid gray;
    margin-left: 7px;
    float: left;
    margin-top: 20px;
}
.person{
    color: white;
    margin-left: 80px;
    margin-top: 150px;
}
.cn{
    color: gray;
    font-size: 12px;
    list-style: none;
    margin-left: -28px;
    margin-top: 8px;
}
.tn{
    list-style: none;
    color: white;
    margin-left: -34px;
    font-size: 24px;
    margin-top: 15px;
}
</style>


