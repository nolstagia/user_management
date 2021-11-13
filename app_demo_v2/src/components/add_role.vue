<template>
<div class="row">
  <h3 style="text-align: left">ADD ROLE</h3>

  <div class="col-md-6 dis-h pad-top1">
         
    <label for="inputName" class="col-sm-2 lab-a">Role name: </label>
    <div class="col-sm-8">
      <input
        
        class="form-control inp-a border-cus"
        v-model="role_name"
        id="inputName"
        placeholder="Role name"
        
      />
    </div>
  </div>

  

  
 
  <div class="col-md-12 margin-custom">
        <div class="flexx">
          
          <button class="btn btn-danger ml-5">
            Cancel
          </button>

          <button @click="add_role" class="btn btn-success ml-5">
              Save
          </button>
        </div>
      </div>
</div>
  
</template>

<script>


export default {
  name: "add_role",

  data: () => ({
      role_name: ""
  }),

  methods:{
    add_role(){
      var vm = this;
      var data = {
        name: vm.role_name
      }
      vm.axios.post('api/Role/CreateRole', data)
      vm.$alert("Successfully added role");
      vm.$router.push('/roles')
      vm.$forceUpdate()
    }
  }

};
</script>

<style scoped>                                                                              
.border-cus{
  border-radius: 6px;
  border: 1px solid #ced4d3;
}

.pad-top1{
  padding-top: 15px;
}
.flexx{
  margin-right: 30%;
}

</style>

