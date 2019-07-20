<template>
  <div class="user-detail">
    <form method="post" action="https://localhost:44359/api/values/" enctype="multipart/form-data">
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
      user:{
          "id":'0',
          "eId":'',
          "chiName": '',
          "engName":'',
          "passWordSalt":'123',
          "passWordHash":'123',
          "email":'',
          "phoneNum":'',
          "loginErrorTimes":0,
          "lastFailedAttemptDateTime":null,
          "lastLogOnDateTime":null,
          "lastPasswordUpdateDateTime":null,
          "isDeleted":'0',
          "createdBy":'admin',
          "createdDate":'2019-07-20 19:00:00',
          "lastUpdatedBy":'',
          "lastUpdatedDate":'2019-07-20 19:00:00'
      }
    };
  },
  created() {

  },
  methods:{
    submit:function(){
      console.log(this.user);
      this.$axios.post("https://localhost:44359/api/values/",this.user).then((response)=>{
        console.log(response);
      });
    }
  }
};
</script>
