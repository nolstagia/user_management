<template>
  <div>
    <div class="row">
      <h3 class="t-left">PERMISSIONS MANAGEMENT</h3>

      <div class="col-md-12 margin-customs">
        <div class="flexx">

          
          
          <button @click="deletePer" class="btn btn-danger ml-5">
            <font-awesome-icon class="icon-2" icon="trash" />
            Delete
          </button>

          <button class="btn btn-success ml-5">
            
              <router-link to="/add_permission" class="white"> Add New </router-link>
          
          </button>
        </div>
      </div>
      <table class="table table-striped table-bordered">
        <thead>
          <tr>
            <th scope="col"></th>
            <th>id</th>
            <th scope="col">Permission</th>
            <th scope="col">Screen</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="permission in list_permission" :key="permission.id" >
            <th scope="row"><input type="checkbox" v-model="permission.checked" /></th>
            <td>{{permission.id}}</td>
            <td>{{permission.name}}</td>
            <td>{{permission.screen}}</td>
            
          </tr>



        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
export default {
  name: "permissions",
  data () {
    return {
      list_permission: [],

    }
  },
  mounted() {
    this.getPermission();
  },

  methods:{

    getPermission(){
      var vm = this;
      
      vm.axios.get('/api/Permission')
              .then((response) => {
                vm.list_permission = response.data
              });
    },
    deletePer()
    {
      if (confirm("Are you sure")) {
        var vm = this
        
        var permission_delete = vm.list_permission.filter(item => item.checked == true);
        var ids = [];
        permission_delete.forEach(element => {
          ids.push(element.id)
        });
        
        vm.axios.delete("/api/Permission/DeletePermission",{data:ids})
        vm.$alert("Successfully deleted!");
        vm.getPermission();
        vm.$forceUpdate();
      }
    }
  }
}
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

.white{
  color: white;
  text-decoration: none;
}
</style>

