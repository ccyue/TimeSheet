<template>
    <div class="user-list">
        <el-button type="primary" size="medium" @click="handleAdd">New User</el-button>
        <el-table :data="tableData" style="width: 100%">
            <el-table-column label="No" type="index" show-overflow-tooltip width="50"></el-table-column>
            <el-table-column label="E-ID" width="120" prop="eId"></el-table-column>
            <el-table-column label="English Name" width="120" prop="engName"></el-table-column>
            <el-table-column label="Chinese Name" width="120" prop="chiName"></el-table-column>
            <el-table-column label="Gender" width="100" prop="gender" :formatter="genderFormat"></el-table-column>
            <el-table-column label="Born Date" width="100" prop="bornDate" :formatter="dateFormat"></el-table-column>
            <el-table-column label="Employee No" width="110" prop="employeeNo"></el-table-column>
            <el-table-column label="Email" width="220" prop="email"></el-table-column>
            <el-table-column label="Phone Num" width="120" prop="phoneNum"></el-table-column>
            <el-table-column label="Status" width="120">
            <template slot-scope="scope">
                <span>{{ scope.row.status===0?"Valid":"Invalid" }}</span>
            </template>
            </el-table-column>
            <el-table-column label="Action">
            <template slot-scope="scope">
                <el-button
                size="mini"
                @click="handleEdit(scope.$index, scope.row)">Edit</el-button>
                <el-button
                size="mini"
                type="danger"
                @click="handleDelete(scope.$index, scope.row)">Delete</el-button>
            </template>
            </el-table-column>
        </el-table>
    </div>
</template>

<script>
export default {
    data(){
        return {
            tableData:[]
        }
    },
    created(){
        this.axios.get("api/users").then(response=>{
            if(response.status=="ok")
            {
                this.tableData = response.data;
            }
        })
    },
    methods:{
        handleAdd() 
        {
            this.$router.replace({ path: "/user/add/" });
        },
        handleEdit(index, row) 
        {
            this.$router.replace({ path: "/user/edit/" + row.id });
        },
        handleDelete(index, row) 
        {
             this.$axios.delete("/api/users/"+row.id).then(data => {
                this.tableData.splice(index,1);
            });
        },
        dateFormat(row,column){
            var t=new Date(row.bornDate);
            console.log(t);
            return t.getFullYear()+"-"+(t.getMonth()+1)+"-"+t.getDate();
        },
        genderFormat(row,column){
           
            return row.gender===true?"Male":"Female";
        }
    }
}
</script>

