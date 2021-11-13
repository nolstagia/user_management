<template>
  <div class="row">
    <h3 class="t-left">USERS</h3>
    
    <div class="col-md-12 margin-custom">
      <div class="row">
        
        <div class="col-md-3 dis-h">
         
          <label for="inputName" class="col-sm-4 lab-a">Full name: </label>
          <div class="col-sm-8">
            <input
              v-model="FullName"
              class="form-control inp-a bor-r-6"
              id="inputName"
              placeholder="Fullname"
              
            />
          </div>
        </div>

        <div class="col-md-3 dis-h">
          <label for="inputGmail" class="col-sm-4 lab-a">Email: </label>
          <div class="col-sm-8">
            <input
              v-model="Email"
              class="form-control inp-a bor-r-6"
              id="inputGmail"
              placeholder="Email"
            />
          </div>
        </div>

        <div class="col-md-2">
          <button @click="searchUser" class="btn btn-danger search-btn d-flex">
            <font-awesome-icon class="icon-2" icon="search" />
            Search
          </button>
        </div>
        <div class="col-md-4 dis-cus">
          <button class="btn btn-primary ml-5">
            <router-link to="/set_role" class="white">
            Set role
            </router-link>
          </button>

          <button @click="deleteUser" class="btn btn-danger ml-5" >
            <font-awesome-icon class="icon-2" icon="trash" />
            Delete
          </button>

          <button class="btn btn-success ml-5" >
            <router-link to="/add" class="white">
            Add New
            </router-link>
          </button>
        </div>
      </div>
    </div>
    <table class="table table-striped table-bordered">
      <thead>
        <tr>
          <th scope="col"></th>
          <th scope="col">id</th>
          <th scope="col">Full name</th>
          <th scope="col">Birth</th>
          <th scope="col">Address</th>
          <th scope="col">Username</th>
          <th scope="col">Email</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in list_user" :key="user.id">
          <th scope="row"><input v-model="user.checked" type="checkbox" /></th>
          <td>{{user.id}}</td>
          <td>{{user.fullName}}</td>
          <td>{{user.birthDay | formatDate}}</td>
          <td>{{user.address}}</td>
          <td>{{user.userName}}</td>
          <td>{{user.email}}</td>
          <td>
            <div>
              <button class="btn btn-success  ml-5">
                <router-link :to="{ name: 'edit', params: { id: user.id}}" class="white">
                <font-awesome-icon class="icon-2 white" icon="pencil-alt" />
                  </router-link>
             </button>
              <button class="btn btn-danger  ml-5">
                <i>
                  <font-awesome-icon class="icon-2" icon="trash" />
                </i>
              </button>
              <button class="btn btn-primary ml-5">
                <router-link :to="{ name: 'userInfo', params: { id: user.id}}">
                <i  style="color: white">
                  <font-awesome-icon class="icon-2" icon="info" />
               </i>
                 </router-link>
              </button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "users",
  data () {
    return {
      list_user: [],
      FullName:"",
      Email:"",
    }
  },

  mounted() {
    this.searchUser();
  },
  methods: {


    deleteUser()
    {
      
      if (confirm("Are you sure")) {
        var vm = this
        // get user to be deleted
        var user_delete = vm.list_user.filter(item => item.checked == true);
        var ids = [];
        user_delete.forEach(element => {
          ids.push(element.id)
        });
        
        vm.axios.delete("/api/Users/DeleteUser",{data:ids})
        vm.$alert("Successfully deleted!");

        vm.searchUser();

      }
    },
   

     searchUser(){
      var vm = this;
      var par = {
        fullname: vm.FullName,
        email: vm.Email
      }

      vm.axios.get('/api/Users', {
                params: par
              })
              .then((response) => {
                vm.list_user = response.data
              });
    }
  },
  
};
</script>

<style scoped>
  .table thead{
    background-color: #2166ac;
    color: #fff;
    text-align: center;
  }

  .l-mar{
    margin-left: 15px;
  }
  .inp-cus{
    height: 32px;
    border-radius: 5px;
    border: solid black 1px;
    padding-left: 5px;
  }

  .white{
    color: white;
    text-decoration: none;
  }
</style>