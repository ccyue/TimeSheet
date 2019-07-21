<template>
  <div class="user-detail">
    <form method="put" action="api/users/" enctype="multipart/form-data">
      <table>
        <tr>
          <td>eid</td>
          <td><input type="text" v-model="user.eId"></td>
        </tr>
        <tr>
          <td>English Name</td>
          <td><input type="text" v-model="user.engName"></td>
        </tr>
        <tr>
          <td>Chinese Name</td>
          <td><input type="text" v-model="user.chiName"></td>
        </tr>
        <tr>
          <td>E-mail</td>
          <td><input type="text" v-model="user.email"></td>
        </tr>
        <tr>
          <td>Phone Num</td>
          <td><input type="text" v-model="user.phoneNum"></td>
        </tr>
        <tr>
          <td>Status</td>
          <td><input type="text" v-model="user.isDeleted"></td>
        </tr>
        <tr>
          <td></td>
          <td><input type="button" value="Submit" @click="submit"></td>
        </tr>
      </table>
    </form>

  </div>
</template>
<script>
export default {
  data() {
    return {
      user:''
    };
  },
  created() {
    const id = this.$route.params.id;
    this.$axios.get("api/users/"+id).then(response => {
      if(response.status=="ok")
      {
        this.user=response.data;
      }
    });

    console.log(id);
  },
  methods:{
    submit:function(){
      console.log(this.user);
      this.$axios.put("api/users/"+this.user.id,this.user).then((response)=>{
        if(response.status=="ok")
        {
            this.$router.replace({ path: "/user/list/"});
        }
      });
    }
  }
};
</script>
