import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/user/list",
      name: "user-list",
      component: () => import("./views/User/UserList.vue")
    },
    {
      path: "/user/detail/:id",
      name: "user-detail",
      component: () => import("./views/User/UserDetail.vue")
    },
    {
      path: "/user/add/",
      name: "user-add",
      component: () => import("./views/User/UserAdd.vue")
    }
  ]
});
