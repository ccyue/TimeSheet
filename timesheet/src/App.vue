<template>
  <div id="app">
    <el-row>
      <el-col :span="24">
        TimeSheet
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="3">
        <el-menu :default-active="this.$router.path" router mode="horizontal">
          <el-menu-item v-for="(item,i) in navList" :key="i" :index="item.name">
            {{ item.navItem }}
          </el-menu-item>
        </el-menu>
      </el-col>

      <el-col :span="21">
        <router-view />
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  data(){
    return{
      navList:[]
    }
  },
  created(){
    this.navList = [
      {name:'/user/list',navItem:'User List'},
      //{name:'/projects/list',navItem:'Project List'},
    ]
  }
}
</script>


