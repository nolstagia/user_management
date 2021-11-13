<template>
  <div>
    <div class="row">
      <h3 style="text-align: left">ROLE MANAGEMENT</h3>

      <div class="col-md-12 margin-custom">
        <div class="flexx">

          <button class="btn btn-primary ml-5">
            
            <router-link to="/set_permission" class="white"> Set Permission </router-link>
          </button>

          <button @click="deleteRole" class="btn btn-danger ml-5">
            <font-awesome-icon class="icon-2" icon="trash" />
            Delete
          </button>

          <button class="btn btn-success ml-5">
            <router-link to="/add_role" class="white"> Add New </router-link>
          </button>
        </div>
      </div>
      <table class="table table-striped table-bordered">
        <thead>
          <tr>
            <th scope="col"></th>
            <th scope="col">id</th>
            <th scope="col">Name</th>
            
          </tr>
        </thead>

        <tbody>
          <tr v-for="role in list_role" :key="role.id">
            <th scope="row"><input v-model="role.checked" type="checkbox" /></th>
            <td>{{role.id}}</td>
            <td>{{role.name}}</td>

          </tr>

          
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
export default {
  name: "roles",
  data () {
    return {
      list_role: [],
    }
  },
  mounted() {
    this.getRole();
  },
  methods:{

    getRole(){
      var vm = this;
      
      vm.axios.get('/api/Role')
              .then((response) => {
                vm.list_role = response.data
              });
    },

    deleteRole()
    {
      
      if (confirm("Are you sure")) {
        var vm = this
        
        var role_delete = vm.list_role.filter(item => item.checked == true);
        var ids = [];
        role_delete.forEach(element => {
          ids.push(element.id)
        });
        
        vm.axios.delete("/api/Role/DeleteRole",{data:ids})
        vm.$alert("Successfully deleted!");
        vm.getRole();
        vm.$forceUpdate();
      }
    },

  }
};
</script>

<style scoped>
.table thead {
  background-color: #2166ac;
  color: #fff;
  text-align: center;
}
.table tbody {
  text-align: center;
}

.flexx {
  display: flex;
  justify-content: flex-end;
  margin-right: 8%;
}

.white {
  color: white;
  text-decoration: none;
}


</style>

