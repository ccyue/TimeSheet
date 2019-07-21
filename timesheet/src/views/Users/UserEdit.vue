<template>
    <div class="user-edit">
        <el-form ref="form" label-width="100px">
            <el-form-item label="E-ID">
                <el-input v-model="user.eId"></el-input>
            </el-form-item>
            <el-form-item label="English Name">
                <el-input v-model="user.engName"></el-input>
            </el-form-item>
            <el-form-item label="Chinese Name">
                <el-input v-model="user.chiName"></el-input>
            </el-form-item>
            <el-form-item label="Gender">
                <el-radio-group v-model="user.gender">
                    <el-radio :label="true">Male</el-radio>
                    <el-radio :label="false">Female</el-radio>
                </el-radio-group>
            </el-form-item>
            <el-form-item label="Born Date">
                <el-date-picker type="date" v-model="user.bornDate" placeholder=""></el-date-picker>
            </el-form-item>
            <el-form-item label="Employee No">
                <el-input v-model="user.employeeNo"></el-input>
            </el-form-item>
            <el-form-item label="Email">
                <el-input v-model="user.email"></el-input>
            </el-form-item>
            <el-form-item label="Phone Num">
                <el-input v-model="user.phoneNum"></el-input>
            </el-form-item>
            <el-form-item label="Status">
                <el-select v-model="user.status">
                <el-option label="正常" :value="0" ></el-option>
                <el-option label="禁用" :value="1"></el-option>
                </el-select>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="onSubmit">Save</el-button>
                <el-button @click="onCancel">Cancel</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>
<script>
export default {
    data(){
        return{
            user:''
        }
    },
    created()
    {
        const id = this.$route.params.id;
        this.$axios.get("api/users/"+id).then(response=>{
            if(response.status=="ok")
            {
                this.user=response.data;
            }
        })
    },
    methods:{
        onSubmit:function()
        {
            this.$axios.put("api/users/"+this.user.id,this.user).then(response=>{
                if(response.status=="ok")
                {
                    this.$router.replace({ path: "/user/list/"});
                }
            })
        },
        onCancel:function()
        {
            this.$router.replace({ path: "/user/list/"});
        }
    }
}
</script>
