<template>
  <div class="table" style="margin-left:30px;margin-top:40px;width: 100%;hightL100%">
     
     <div>
       
       <div style="width:370px;height:60px;background-color:skyblue;float:left">

         <span class="el-icon-upload" style="line-height:60px;margin-left:10px;font-size:20px;color:white">上传课程：7782</span>

       </div>
       <div style="width:370px;height:60px;background-color:skyblue;float:left;margin-left:30px">

         <span class="el-icon-thumb" style="line-height:60px;margin-left:10px;font-size:20px;color:white">课程被浏览：7732</span>

       </div>
       <div style="width:370px;height:60px;background-color:skyblue;float:left;margin-left:30px">

         <span class="el-icon-goods" style="line-height:60px;margin-left:10px;font-size:20px;color:white">课程被购买：7752</span>

       </div>

     </div>
      <!--头-->
        
      <!--身子-->
      <div style="width: 100%;margin-top:120px;">
        <!--第一个图表-->
        <div style="width:100%;height:200px">
          <el-breadcrumb separator-class="el-icon-arrow-right">
            <el-breadcrumb-item>直播课程分析</el-breadcrumb-item><!--:to="{ path: '/' }"-->
          </el-breadcrumb>
          <!--为echarts准备一个具备大小的容器dom-->
            <div id="main1"  style="width:100%;height:200px;margin-top:-10px;margin-left:-10px">

            </div>
        </div>
        <!--第二个图表-->
        <div style="width:100%;height:200px">
          <el-breadcrumb separator-class="el-icon-arrow-right">
            <el-breadcrumb-item>课程分析</el-breadcrumb-item><!--:to="{ path: '/' }"-->
          </el-breadcrumb>
          <!--为echarts准备一个具备大小的容器dom-->
            <div id="main" style="width: 100%;height: 200px;margin-top:-10px;margin-left:-10px">

            </div>
        </div>
        <!--是商品表格-->
        <div style="margin-top:10px">
          <el-breadcrumb separator-class="el-icon-arrow-right">
            <el-breadcrumb-item>课程订购分析</el-breadcrumb-item><!--:to="{ path: '/' }"-->
          </el-breadcrumb>

           <el-table :data="datagoods" border style="width: 100%">
              <el-table-column prop="goodsId" label="课程分类">
              </el-table-column>
              <el-table-column prop="imageShow" label="课程图片">
                <template slot-scope="scope">
                    <img :src="'http://10.3.181.46:5000/'+scope.row.imageShow" style="width: 50px; height: 45px" />
                </template>
              </el-table-column>
              <el-table-column prop="goodsName" label="课程名称">
              </el-table-column>
              <el-table-column prop="goodsPrice" label="浏览次数">
              </el-table-column>
              <el-table-column prop="unit" label="购买次数" >
              </el-table-column>
             
            </el-table>
        </div>
      </div>
  </div>
</template>

<script>

import *as echarts from 'echarts';

  export default {
    name: '',
      data() {
        return {

          charts: '',

          datagoods:[],

          tableData:[],

          opinionData: ["2", "8", "5", "9", "11"],
          
          posionData:["5", "12", "16", "8", "13"]
        }
      },
      mounted() {
          // this.videoid = this.$route.query.id;
          // //alert(this.videoid);
          // //查询直播详情
          // this.selectvideo();
          // this.selectvideogoods();
          //获取图表数据
        this.$nextTick(function() {
                this.drawLine('main')
            });
        
        this.$nextTick(function() {
                this.drawLinetable('main1')
            });
        
      },
      methods: {
        //查询数据
        selectvideo(){
              this.$axios.get(
            "api/selectvideo?videoid=" +this.videoid
          )
          .then(r => {
            //alert(JSON.stringify(this.tableData));
            this.tableData = r.data.data;
          });
        },
        //查询商品
        selectvideogoods(){
            this.$axios.get(
              "api/SelectVideoGoods?videoid=" +this.videoid
            )
            .then(r => {
              //alert(JSON.stringify(r.data.data));
              this.datagoods = r.data.data;
            });
        },
        // //获取图表数据
        // GetEacths(){
        //   this.$axios.get("/api/GetEacths?videoid="+this.videoid)
        // .then(r => {
        //   // alert(JSON.stringify(r.data.data));
        //   // alert(JSON.stringify(r.data.data[0].looknum));
        //   //获取点赞数
        //   r.data.data[0].looknum.forEach((item) => {
        //     this.looknum.push(JSON.stringify(item.givelike));
        //   })
        //   //订单量
        //   r.data.data[0].ordernum.forEach((item)=>{
        //     if(item.givelike==null)
        //     {
        //       this.goodsNum.push("2");
        //     }
        //       this.goodsNum.push(JSON.stringify(item.goodsNum));
        //   })
        //   //获取直播时长
        //    r.data.data[0].videotime.forEach((item)=>{
        //     if(item.givelike==null)
        //     {
        //       this.videoHour.push("45");
        //     }
        //       this.videoHour.push(JSON.stringify(item.videoHour));
        //   })

        // }).then(()=>{
        //     //alert(JSON.stringify(this.NewData));
        //      this.drawLinetable('main1');
        //      this.drawLine('main');
        //   });
        // },
        //图表2
        drawLine(id) {

            this.charts = echarts.init(document.getElementById(id))
                this.charts.setOption({
                    tooltip: {
                        trigger: 'axis'
                    },
                    legend: {
                        data: ['订单金额与收益']
                    },
                    grid: {
                        left: '3%',
                        right: '4%',
                        bottom: '3%',
                        containLabel: true
                    },
 
                    toolbox: {
                        feature: {
                            saveAsImage: {}
                        }
                    },
                    xAxis: {
                        type: 'category',
                        boundaryGap: false,
                    data: ["2021-01","2021-02","2021-03","2021-04","2021-05"]
                    
                    },
                    yAxis: {
                        type: 'value'
                    },
 
                    series: [{
                        name: '近七日收益',
                        type: 'line',
                        stack: '总量',
                        data: this.opinionData
                    }]
                })
               
        },
        //图表1
        drawLinetable(id) {
              
              this.charts = echarts.init(document.getElementById(id))
                this.charts.setOption({
                    tooltip: {
                        trigger: 'axis'
                    },
                    legend: {
                        data: ['订单金额与收益']
                    },
                    grid: {
                        left: '3%',
                        right: '4%',
                        bottom: '3%',
                        containLabel: true
                    },
 
                    toolbox: {
                        feature: {
                            saveAsImage: {}
                        }
                    },
                    xAxis: {
                        type: 'category',
                        boundaryGap: false,
                    data: ["2021-01","2021-02","2021-03","2021-04","2021-05"]
                    
                    },
                    yAxis: {
                        type: 'value'
                    },
 
                    series: [{
                        name: '近七日收益',
                        type: 'line',
                        stack: '总量',
                        data: this.posionData
                    }]
                })

        },
      },
  
  }
</script>

<style scoped>
  .pagination{
        float:right;
        margin-right:500px;
    }
  .slide-enter-active, .slide-leave-active {
    transition: all 0.5s linear;
  }
  .slide-enter{
    transform: translateY(20px) scale(1);
    opacity: 1;
  }
  .slide-leave-to {
    transform: translateY(-20px) scale(0.8);
    opacity: 0;
  }
  .table{
    height: 100%;
    width: 100%;
  }
</style>
