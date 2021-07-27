<template>
    <div>
      <el-header style="text-align: right; font-size: 12px">
      <h3>八维在线教育教师端</h3>
      <el-dropdown>
        <i class="el-icon-setting" style="margin-right: 15px"></i>
        <el-dropdown-menu slot="dropdown">
          <el-dropdown-item>查看</el-dropdown-item>
          <el-dropdown-item>新增</el-dropdown-item>
          <el-dropdown-item>删除</el-dropdown-item>
        </el-dropdown-menu>
      </el-dropdown>
    </el-header> 
<el-container style="height: 800px; border: 1px solid #eee;">
  <el-aside width="200px" style="background-color: #474f57">
    <el-menu :default-active="2"
      class="el-menu-vertical-demo"
      @open="handleOpen"
      @close="handleClose"
      background-color="#474f57"
      text-color="#fff"
      :router='true'
      active-text-color="#ffd04b">
     
      <el-submenu v-for="item in data" :key='item.id'  :index="item.index">
        <template slot="title"><i :class="item.icon"></i>{{item.name}}</template>
        <el-menu-item v-for="v in item.children" :key='v.id' :index="v.index">{{v.name}}</el-menu-item>
      </el-submenu>
    </el-menu>
  </el-aside>
  
  <el-container>
    <div></div>
    <router-view />
  </el-container>
</el-container>
    </div>
    
</template>
<style>
  .el-header {
    background-color: #3a8ed3;
    color: #fff;
    line-height: 60px;
  }
  .el-aside {
    color: #333;
  }
  h3{
    float: left;
  }
</style>

<script>

  export default {
    methods: {
      handleOpen(key, keyPath) {
        console.log(key, keyPath);
      },
      handleClose(key, keyPath) {
        console.log(key, keyPath);
      },
      handleSizeChange(val) {
        console.log(`每页 ${val} 条`);
      },
      handleCurrentChange(val) {
        console.log(`当前页: ${val}`);
      }
    },
    data() {   
      return {

  data:[{
           name:"工作台",
           index:"/main/work",
        },
        {
           name:"课程管理",
           index:"/main/teacher",
        },
        {
           name:"直播管理",
           index:"/main/video",
           
        },,
        {
           name:"首页",
           index:"/start",
           
        },
        {
           name:"登录",
           index:"/login",
           
        },
        {
           name:"直播",
           index:"/video",
           
        },
        {
           name:"测试",
           index:"/test",
           
        },
        {
           name:"未直播",
           index:"/Nvideo",
           
        }

        ],
       
      }    
    },
  };

</script>