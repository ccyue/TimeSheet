<template>
  <div class="user-list">
    <input type="button" value="New User" @click="addUser">
    <table class="table">
      <thead>
        <tr>
          <th>No.</th>
          <th>Eid</th>
          <th>English Name</th>
          <th>Chinese Name</th>
          
          <th>E-mail</th>
          <th>Phone Num</th>
          <th>Status</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(user,index) in list" :key="index">
          <td>{{index + 1}}</td>
          <td>{{user.eId}}</td>
          <td>{{user.engName}}</td>
          <td>{{user.chiName}}</td>
          
          <td>{{user.email}}</td>
          <td>{{user.phoneNum}}</td>
          <td>{{user.status === 0 ? "正常" : "禁用"}}</td>
          <td> <input type="button" value="Edit" @click="linkToDetail(user.id)"/>&nbsp;<input type="button" value="Delete" @click="deleteUser(user.id)"/> </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
<script>
export default {
  data() {
    return {
      list: []
    };
  },
  created() {
    this.$axios.get("/api/users").then(response => {
      console.log(response);
      if(response.status = "ok")
      {
        this.list = response.data;
      }
    });
    // this.list = [
    //   {
    //     id: 0,
    //     name: "王勋",
    //     eid: "xun.c.wang",
    //     email: "xun.c.wang@accenture.com",
    //     role: 0, // 0 admin 1PM  2 user
    //     status: 1 //0 正常 1禁用
    //   },
    //   {
    //     id: 1,
    //     name: "湖泊",
    //     eid: "bo.a.hu",
    //     email: "bo.a.hu@accenture.com",
    //     role: 2, // 0 admin 1PM  2 user
    //     status: 0 //0 正常 1禁用
    //   },
    //   {
    //     id: 2,
    //     name: "顾大萌",
    //     eid: "dameng.gu",
    //     email: "dameng.gu@accenture.com",
    //     role: 1, // 0 admin 1PM  2 user
    //     status: 0 //0 正常 1禁用
    //   }
    // ];
  },
  methods: {
    roleChangeToText(role) {
      let roleArr = ["admin", "PM", "user"];
      return roleArr[role];
    },
    linkToDetail(id) {
      this.$router.replace({ path: "/user/detail/" + id });
    },
    deleteUser(id,index){
        this.$axios.delete("/api/users/"+id).then(data => {
        this.list.splice(index+1,1);
      });
    },
    addUser()
    {
      this.$router.replace({ path: "/user/add/"});
    }
  }
};
</script>
<style lang="scss" scoped>
.user-list {
  .table {
    margin: 0 auto;
    th,
    td {
      border: 1px solid black;
    }
  }
}
</style>
