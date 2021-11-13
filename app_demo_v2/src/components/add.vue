<template>
  <div>
    <h3>ADD USER</h3>
    <form @submit.prevent="submitForm" id="add_user" class="form-format1">
      <b-container>
        <b-row>
          <b-col>
            <div class="form-group pad-top">
              <label> Full Name <span class="text-danger">*</span> </label>
              <input v-model="fullName" type="text" class="form-control" />
              <span v-if="!$v.fullName.required && $v.fullName.$dirty" class="text-danger span-cus">
                A valid fullName is required !
              </span>
              
            </div>

            <div class="form-group pad-top">
              <label> Email <span class="text-danger">*</span> </label>
              <input v-model="email" type="email" class="form-control" />
              <span v-if="(!$v.email.required || !$v.email.email) && $v.email.$dirty" class="text-danger span-cus">
                A valid email is required !
              </span>
            </div>

            <div class=" form- group pad-top">
              <label>Date of birth <span class="text-danger">*</span></label>
              <b-form-datepicker v-model="birthDay" class=""></b-form-datepicker> 
              <span v-if="!$v.birthDay.required && $v.birthDay.$dirty" class="text-danger span-cus">
                Date of birth required !
              </span>
            </div>

          
            <div class="form-group pad-top">
              <label> Address <span class="text-danger">*</span> </label>
              <input v-model="address" type="text" class="form-control" />
              <span v-if="!$v.address.required && $v.address.$dirty" class="text-danger span-cus">
                Address required !
                </span>
            </div>

          </b-col>

          <b-col>
            
           <div class="form-group pad-top">
              <label> Username <span class="text-danger">*</span> </label>
              <input v-model="userName" type="text" class="form-control" />
              <span v-if="!$v.userName.required && $v.userName.$dirty" class="text-danger span-cus">
                Username required !
              </span>
            </div>

            <div class="form-group pad-top">
              <label> Password <span class="text-danger">*</span> </label>
              <input v-model="password" type="password" class="form-control" />
              <span v-if="!$v.password.required && $v.password.$dirty" class="text-danger span-cus"> 
                Password required !
              </span>
              <span v-if="(!$v.password.minLength || !$v.password.maxLength)&& $v.password.$dirty" class="text-danger span-cus">
                Password must be between 6 and 12 character !
              </span>
              <!-- <span v-if="!$v.password.alphaNum && $v.password.$dirty" class="text-danger span-cus"> Password must not contain special characters!</span> -->
            </div>

            
          </b-col>
        </b-row>
      </b-container>
      <div class="form-group customary2">
        <button type="submit" class="btn btn-success">ADD</button>
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

  // alphaNum,
} from "vuelidate/lib/validators";
export default {
  name: "add",
  data: () => ({
    fullName: "",
    email: "",
    address: "",
    birthDay: "",
    userName: "",
    password: "",
    checked: false,
    
  }),
  validations: {
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
      // alphaNum,
      maxLength: maxLength(12),
      minLength: minLength(6),
    },
  
    userName:{
      required,
    }
  },

  mounted() {
    
  },

  methods: {
    submitForm(){
      this.$v.$touch();

      if(!this.$v.$invalid){
        console.log(
          `fullName: ${this.fullName}, 
          Email: ${this.email}, 
          Address: ${this.address}, 
          Birth: ${this.birthDay}, 
          Username: ${this.userName}, 
          Password: ${this.password}`)
        var vm = this;
        var Data = {
          FullName: vm.fullName,
          BirthDay: vm.birthDay,
          Email: vm.email,
          Address: vm.address,
          UserName: vm.userName,
          Password: vm.password
        }
        vm.axios.post('/api/Users/CreateUser', Data)
        vm.$alert("Successfully added user");
        vm.$router.push('/users')
        vm.$forceUpdate()
        
        }
      
    }
  },
};
</script>


<style scoped>

</style>
