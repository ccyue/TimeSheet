import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/user/list",
      name: "user-list",
      component: () => import("./views/Users/UserList.vue")
    },
    {
      path:"/user/edit/:id",
      name:"user-edit",
      component:()=>import("./views/Users/UserEdit.vue")
    },
    {
      path:"/user/add",
      name:"user-add",
      component:()=>import("./views/Users/UserAdd.vue")
    }
  ]
});
