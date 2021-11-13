<template>
    <div>
    <h3>User with id: {{$route.params.id}}</h3>
    <form @submit.prevent="submitForm" id="add_user" class="form-format1">
      <b-container>
        <b-row>
          <b-col>
            <div class="form-group pad-top">
              <label> Full name <span class="text-danger">*</span> </label>
              <input v-model="user.fullName" type="text" class="form-control" />
              <span v-if="!$v.user.fullName.required" class="text-danger span-cus">
                A valid name is required !
              </span>
              
            </div>

            <div class="form-group pad-top">
              <label> Email <span class="text-danger">*</span> </label>
              <input v-model="user.email" type="email" class="form-control" />
              <span v-if="!$v.user.email.required || !$v.user.email.email" class="text-danger span-cus">
                A valid email is required !
              </span>
            </div>

            <div class=" form- group pad-top">
              <label>Date of birth <span class="text-danger">*</span></label>
              <!-- <input v-model="birthDay" type="text" class="form-control" /> -->
              <b-form-datepicker v-model="user.birthDay" class=""></b-form-datepicker> 
              <span v-if="!$v.user.birthDay.required" class="text-danger span-cus">
                Date of birth required !
              </span>
            </div>

          
            <div class="form-group pad-top">
              <label> Address <span class="text-danger">*</span> </label>
              <input v-model="user.address" type="text" class="form-control" />
              <span v-if="!$v.user.address.required" class="text-danger span-cus">
                Address required !
              </span>
            </div>

          </b-col>

          <b-col>
            
           <div class="form-group pad-top">
              <label> Username <span class="text-danger">*</span> </label>
              <input v-model="user.userName" type="text" class="form-control" />
              <span v-if="!$v.user.userName.required" class="text-danger span-cus">
                Username required !
              </span>
            </div>

            <div class="form-group pad-top">
              <label> Password <span class="text-danger">*</span> </label>
              <input v-model="user.password" type="password" class="form-control" />
              <span v-if="!$v.user.password.required " class="text-danger span-cus"> 
                Password required !
              </span>
              <span v-if="!$v.user.password.minLength || !$v.user.password.maxLength" class="text-danger span-cus"> 
                Password must be between 6 and 12 character !
              </span>
              <!-- <span v-if="!$v.password.alphaNum && $v.password.$dirty" class="text-danger span-cus"> Password must not contain special characters!</span> -->
            </div>

            
          </b-col>
        </b-row>
      </b-container>
      <div class="form-group customary2">
        <button type="submit" class="btn btn-primary">EDIT USER</button>
      </div>
    </form>
  </div>
</template>

<script>
import {
  required,
  minLength,
  maxLength,

  email,


} from "vuelidate/lib/validators";
export default {
  name: "edit",
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
   
  
  validations: {
    user:{
      fullName: {
        required,
        
      },
      email: {
        required,
        email,
      },
      address: {
        required,
      },
      birthDay: {
        required,
      },
      password: {
        required,

        maxLength: maxLength(12),
        minLength: minLength(6),
      },
    
      userName:{
        required,
      }
    }

  },



  methods: {
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
    submitForm(){
      this.$v.$touch();

      if(!this.$v.$invalid){
        
        if (confirm("Are you sure")) {
        var vm = this;
        const url = `/api/users/${vm.selectedId}`;
        var Data = {
          FullName: vm.user.fullName,
          BirthDay: vm.user.birthDay,
          Email: vm.user.email,
          Address: vm.user.address,
          UserName: vm.user.userName,
          Password: vm.user.password
        }
        vm.axios.put(url,Data);
        
      }

      vm.$alert("Successfully update user");
        vm.$router.push('/users')
        vm.$forceUpdate();

      }

    }
  },
};

</script>

