<template>
  <div>
    <h3>SET PERMISSIONS</h3>
    <b-container class="w80">
      <b-row>
        <b-col>
          <div class="">
            <label class="custom">Select Role</label>
            <select v-model="role_id" @change="fetchName()" class="mb-3 custom2">
              <option value="" selected disabled hidden>--Choose role--</option>
              <option v-for="role in list_role" :key="role.id" v-bind:value="role.id">
                {{ role.name }}
              </option>
            </select>
          </div>
          <div class="">
            <label class="custom">Select screen</label>
            <select v-model="screenName" @change="fetchName()" class="mb-3 custom2">
              <option value="" selected disabled hidden>--Choose screen--</option>
              <option v-for="screen in list_screen" :key="screen">{{screen}}</option>

            </select>
          </div>
        </b-col>

        <b-col>
          <div v-for="permission in perOfScreen" :key="permission.id">
            <input v-bind:id="permission.id" class="custom" type="checkbox" v-model="permission.checked">
            <label v-bind:for="permission.id">{{permission.name}}</label>
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

        <button @click="setPermission" class="btn btn-success ml-5">Save</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "set_permission",
  data() {
    return {
      list_role: [],
      list_permission: [],
      list_screen: [],
      perOfScreen: [],
      role_id: "",
      screenName: "",
    };
  },
  mounted() {
    this.getRole();
    this.getPermission();
  },
  methods: {
    getRole() {
      var vm = this;

      vm.axios.get("/api/Role").then((response) => {
        vm.list_role = response.data;
        
      });
    },

    getPermission() {
      var vm = this;

      vm.axios.get("/api/Permission").then((response) => {
        vm.list_permission = response.data;
        vm.list_screen = vm.uniqueBy(vm.list_permission, "screen");
      });
    },


    uniqueBy(arr, prop){
      return arr.reduce((a, d) => {
        if (!a.includes(d[prop])) { a.push(d[prop]); }
        return a;
      }, []);
    },


    fetchName(){
      var vm = this;
      vm.perOfScreen = vm.list_permission.filter(item => item.screen == vm.screenName);
      var par ={
        idRole: vm.role_id
      }
      vm.axios.get("/api/RoleHasPermission/find",{params: par})
      .then((response) => {
        var data = response.data;
        console.log(data);
        vm.perOfScreen.forEach( element => {
          if(data.find(x => x.idPermission == element.id) != null)
            element.checked = true;
          else
            element.checked = false;
        })

        vm.$forceUpdate();
      });      
    },


    setPermission(){
      var vm = this;
      var pids = [];
      var ids = [];

      vm.perOfScreen.forEach(element => {
        ids.push(element.id)
      });

      var deletedata = {
        idRole: vm.role_id,
        idPermissions: ids
      }
      vm.axios.delete("/api/RoleHasPermission/UnsetPermission",{data:deletedata})

      var chosenPer = vm.perOfScreen.filter(item => item.checked == true);
      chosenPer.forEach(element => {
        pids.push(element.id)
      });
      var data = {
        idRole: vm.role_id,
        idPermissions: pids,
      }
      vm.axios.post('/api/RoleHasPermission/SetPermission', data)

      vm.perOfScreen.forEach(element =>{
        element.checked = false
      });


        vm.$alert("Successfully set permission");
        //vm.$router.push('/users')
        //vm.$router.go();
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