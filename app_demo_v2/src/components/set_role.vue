<template>
  <div>
    <h3>SET Role</h3>
    <b-container class="w80">
      <b-row>
        <b-col>
          <div class="">
            <label class="custom">Select User</label>
            <select v-model="user_id" @change="getUserRole" class="mb-3 custom2">
              <option value="" selected disabled hidden>--Choose user--</option>
              <option v-for="user in list_user" :key="user.id" :value="user.id">
                {{ user.fullName }} 
              </option>
            </select>
          </div>
          
        </b-col>

        <b-col>
          <div v-for="role in list_role" :key="role.id">
            <input v-bind:id="role.id" class="custom" type="checkbox" v-model="role.checked">
            <label v-bind:for="role.id" >{{role.name}}</label>
          </div>
        </b-col>
      </b-row>
    </b-container>

    <div class="col-md-12 margin-custom w80">
      <div class="flexx">
        <button class="btn btn-danger ml-5">
          <font-awesome-icon class="icon-2" icon="trash" />
          Cancel
        </button>

        <button @click="setRole" class="btn btn-success ml-5">Save</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "set_role",
  data() {
    return {
      list_user: [],
      list_role: [],
      user_id: "",
      userHasRole: [],
      selectedUserRole: [],
      idds: [],
    };
  },
  mounted() {
    this.getUser();
    this.getRole();
    this.userHasRoles();
  },
  methods: {
    getUser() {
      var vm = this;
      vm.axios.get("/api/Users").then((response) => {
        vm.list_user = response.data;
        
      });

    },

    getUserRole(){
      var vm = this;
      var par ={
        idUser: vm.user_id
      }
      // vm.selectedUserRole = [];

      vm.axios.get("/api/UserHasrole/find",{params: par})
      .then((response) => {
        var data = response.data;
        vm.list_role.forEach( element => {
          if(data.find(x => x.idRole == element.id) != null)
            element.checked = true;
          else
            element.checked = false;
        })

        vm.$forceUpdate();
      });

      
    },


    getRole() {
      var vm = this;
      vm.axios.get("/api/Role").then((response) => {
        vm.list_role = response.data;
      });
    },

    userHasRoles(){
      var vm = this;
      vm.axios.get("/api/UserHasRole").then((response) => {
        vm.userHasRole = response.data;
      });
    },


    setRole(){
      var vm = this;

      var chosenRole = vm.list_role.filter(item => item.checked == true);
      var rids = [];
      var unsetRole = vm.userHasRole.filter(item => item.idUser == vm.user_id);
      var ids = [];

      
      unsetRole.forEach(element => {
          ids.push(element.id)
        });

      vm.axios.delete("/api/UserHasRole/UnsetRole",{data:ids});
      chosenRole.forEach(element => {
          rids.push(element.id)
        });
      var Data = {
        idUser: vm.user_id,
        idRole: rids,
      }
      console.log(ids);
      console.log(rids);

      vm.axios.post('/api/UserHasRole/SetRole', Data)


        vm.list_role.forEach(element =>{
        element.checked = false
      });
        vm.$alert("Successfully set Role");
      vm.axios.get("/api/UserHasRole").then((response) => {
        vm.userHasRole = response.data;
      });
 
    }
    
  },
};
</script>

<style scoped>
.border-cus {
  border-radius: 6px;
  border: 1px solid #ced4d3;
}

.custom {
  margin-right: 10px;
}

.custom2 {
  width: 150px;
  height: 30px;
}

.w80{
  width:80%
}
</style>