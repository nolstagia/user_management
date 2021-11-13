<template>
  <div>
    <h3>USER INFO. ID: {{$route.params.id}}</h3>
    <b-container class="container-cus3">
      <p>Name: {{user.fullName}}</p>
      <p>Date of birth: {{user.birthDay | formatDate}}</p>
      <p>Email: {{user.email}}</p>
      <p>Address: {{user.address}}</p>
      <div class="form-group customary2">
        <button class="btn btn-primary  ml-5">
            EDIT
        </button>

        <button class="btn btn-danger  ml-5">
            DELETE
        </button>
      </div>
    </b-container>
  </div>
</template>

<script>
export default {
  name: "userInfo",
    data () {
    return{
      user: {
      fullName: "",
      email: "",
      address: "",
      birthDay: "",
      userName: "",
      password: "",
      },

      selectedId: this.$route.params.id,
    }    
  },

  mounted(){
    this.preSet();

  },
  methods:{
    preSet(){
      var vm = this;
      var par ={
        id: vm.selectedId
      }
      vm.axios.get('/api/Users/Id', {params:par})
              .then((response) => {
                vm.user = response.data;

            });

    },
  }

}
</script>

<style>
.container-cus3{
  width: 70%;
  margin-left: 15%;
}
p{
  font-size: 20px;
} 
</style>

