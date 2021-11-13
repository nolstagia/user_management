<template>
  <div class="login-page">
    <b-container style="padding-top: 25px">
      <b-row class="justify-content-md-center">
        <b-col cols="5">
          <div class="login-panel panel panel-default">
            <div class="panel-heading customary1">Login</div>
            <div class="panel-body">
              <form @submit.prevent="loginApp">
                <fieldset>
                  <div class="form-group">
                    <input
                      class="form-control customary2"
                      placeholder="Username"
                      v-model="username"
                      autofocus
                      required
                    />
                  </div>
                  <div class="form-group">
                    <input
                      id="password"
                      class="form-control customary2"
                      placeholder="Password"
                      type="password"
                      v-model="password"
                    />
                  </div>
                  <div class="checkbox">
                    <label class="flex checkbox">
                      <p>
                        <input type="checkbox" value="Remember Me" />Remember me
                      </p>
                      <a class="spec" href="">Forgot Password?</a>
                    </label>
                  </div>
                  <button
                    type="submit"
                    class="btn btn-primary btn-block customary2"
                  >
                    <router-link to="/home" class="white"> Login </router-link>
                  </button>
                  <div class="flex2 not_member">
                    <p>Not a member?</p>
                    <a class="spec" href="">Sign up now</a>
                  </div>
                </fieldset>
              </form>
            </div>
          </div>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
export default {
  name: "login",
  data() {
    return {
      username: "",
      password: "",
    };
  },
  methods: {
    loginApp() {
      var vm = this;
      var list_user = JSON.parse(localStorage.getItem("list_user"));
      let index = list_user.findIndex(
        (item) => item.username == vm.username && item.password == vm.password
      );
      if (index >= 0) {
        alert("your information is correct");
        return true;
      } else {
        alert("your information is not correct");
        return false;
      }
    },
  },
};
</script>

<style scoped>
.login-page {
  background-color: #eee;
  font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
  font-size: 14px;
  line-height: 1.42857143;
}

.panel {
  border: 0;
  margin-bottom: 20px;
  background-color: #fff;
  box-shadow: 0 1px 1px rgb(0 0 0 / 5%);
  border-radius: 15px;
}

.panel-heading {
  font-size: 18px;
  font-weight: 300;
  letter-spacing: 0.025em;
  height: 66px;
  line-height: 45px;
  border-radius: 15px 15px 0px 0px;
  background-color: teal;
  color: white;
}

.customary1 {
  text-align: center;
}

.customary2 {
  border-radius: 15px;
}

.panel-body {
  padding: 15px;
}

.form-group {
  margin-bottom: 15px;
}

.form-control {
  display: block;
  width: 100%;
  height: 34px;
  padding: 6px 12px;
  font-size: 14px;
  line-height: 1.42857143;
  color: #555;
  background-color: #fff;
  background-image: none;
}

.checkbox,
.radio {
  position: relative;
  display: block;
  margin-top: 10px;
  margin-bottom: 10px;
}

.checkbox label,
.radio label {
  min-height: 20px;
  padding-left: 20px;
  margin-bottom: 0;
  font-weight: 400;
  cursor: pointer;
}

.flex {
  display: flex;
  flex-direction: row;
  flex-wrap: nowrap;
  justify-content: space-between;
  align-items: stretch;
  align-content: stretch;
}

a {
  text-decoration: none;
}

p {
  font-size: 14px;
}

.btn-block {
  display: block;
  width: 100%;
}

.flex2 {
  display: flex;
  flex-direction: row;
  flex-wrap: nowrap;
  justify-content: center;
  align-items: stretch;
  align-content: stretch;
  margin-top: 20px;
}

.white {
  color: white;
  text-decoration: none;
}
</style>