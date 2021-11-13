<template>
  <div>
    <div class="sidebar" v-bind:class="{ 'active-nav': is_show }">
      <ul class="nav">
        <li class=" nav-item">
          <router-link to="/">
            <font-awesome-icon class="icon" icon="tachometer-alt" />
           <span>Dashboard</span> 
          </router-link>
        </li>
        <li class=" nav-item">
          <router-link to="/users">
            <font-awesome-icon class="icon" icon="list" /> 
            <span>List Users</span>
          </router-link>
        </li>
        <li class=" nav-item">
          <router-link to="/roles">
            <font-awesome-icon class="icon" icon="cog" />
            <span>Roles</span>
          </router-link>
        </li>
        <li class=" nav-item">
          <router-link to="/permissions">
            <font-awesome-icon class="icon" icon="cogs" /> 
            <span>Permission</span>
          </router-link>
        </li>
      </ul>
    </div>

    <!-- Main Wrapper -->

    <!-- <div class="p-1 my-container" v-bind:class="{ 'active-cont': is_show }">
      <button class="btn btn-toggle" @click="ToggleSidebar">
        <i class="bx bx-menu" ><font-awesome-icon class="icon-2" icon="bars"  /></i>
      </button>
    </div> -->
  </div>
</template>

<script>
export default {
  name: "sidebar",
  mounted() {

  },
  data() {
    return {
      is_show: true,
    };
  },

  methods: {
    ToggleSidebar: function () {
      var vm = this;

      vm.is_show = !vm.is_show;
    },
  },
};
</script>

<style scoped>

.nav-item {
  padding: 0;
  width: 100%;
  font-size: 19px;
  text-align: left;
}


.nav-item a{
  text-decoration: none;
  color: #2166ac;
  display: inline-block;
  width: 100%;
  height: 100%;
  padding: 10px 15px 10px 25px;
}

.nav-item a:hover{
  background-color: #fff;
  border-right: 4px solid #2166ac;
  font-weight: bold;
}

.nav-item a.router-link-exact-active{
  background-color: #fff;
  border-right: 4px solid #2166ac;
  font-weight: bold;
}

.nav-item a .icon{
  margin-right: 10px;
  font-size: 15px;
}


.sidebar {
  width: 180px;
  height: 100%;
  position: fixed;
  margin-left: -300px;
  transition: 0.5s;
  background-color: #f1f3f6;
  border-right: 3px #dce3ea
}

.my-container {
  transition: 0.4s;
}

.active-nav {
  margin-left: 0;
}

.active-cont {
  margin-left: 180px;
}

.btn-toggle {
  background-color: #327bf0;
  color: #fff;
  margin-left: -62px;
  position: relative;
  left: -40%;
  margin-left: -200px;
}

.icon-2 {
  margin: 0px;
  z-index: 1;
  color: white;
  size: 20px;
}

.sidebar-light {
  background-color: #f1f3f6;
  --active-border-offset-right: 3px;
  background: inherit;

  border-right: 1px solid #e2e5e8b7;
}


</style>