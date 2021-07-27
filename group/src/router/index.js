import Vue from 'vue'
import Router from 'vue-router'
import axios from '@/utils/request'
import Teacher from '@/components/Teacher'

import VueRouter from 'vue-router'
import login from "../components/login";
import start from "../components/start";
import freeclass from "../components/freeclass";
import study from "../components/study";
import collect from "../components/collect";


// 安装
Vue.use(VueRouter)
Vue.use(Router)
Vue.prototype.$axios=axios;

//导出路由
export default new VueRouter({
  routes:[
    {
      //路径
      path:'/login',
      name:'login',
      //跳转组件
      component:login
    },
    {
      //路径
      path:'/start',
      name:'start',
      //跳转组件
      component:start
    },
    {
    //路径
    path:'/freeclass',
    name:'freeclass',
    //跳转组件
    component:freeclass
    },
    {
    //路径
    path:'/study',
    name:'study',
    //跳转组件
    component:study
    }
    ,
    {
    //路径
    path:'/collect',
    name:'collect',
    //跳转组件
    component:collect
    }
  ]
});

///export default new Router({
  
//   routes: [
//     {
//       path: '/',
//       name: 'Teacher',
//       redirect:"/main",
//       component: Teacher,
//     },
//     {
//       path: '/main',
//       name: 'Main',
//       component: () => import('@/components/Teacher.vue'),
//       redirect:"/main/work",
//       children:
//       [
//       {

//         path:'/main/work',
//         name:'Work',
//         component: () => import('@/pages/Work/index'),

//       },
//       {

//         path:'/main/teacher',
//         name:'Teacher',
//         component: () => import('@/pages/Teacher/index'),

//       },
//       {

//         path:'/main/video',
//         name:'Video',
//         component: () => import('@/pages/Video/index'),

//       }
      
//     ]
//    },
//    {

//     path:'/start',
//     name:'Start',
//     component: () => import('@/pages/Start/index'),

//   },
//   {

//    path:'/login',
//    name:'Login',
//    component: () => import('@/pages/Login/index'),

//  },
//   {

//    path:'/video',
//    name:'Video',
//    component: () => import('@/pages/Video/index'),

//  },
//  {

//   path:'/test',
//   name:'Test',
//   component: () => import('@/pages/Test/index'),

// },
// {

//  path:'/Nvideo',
//  name:'Nvideo',
//  component: () => import('@/pages/Nvideo/index'),

// }
   
//   ]

//})
