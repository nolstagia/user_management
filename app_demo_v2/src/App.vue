<template>
  <div id="app">
    <div v-if="$route.meta.loginScreen">
      <router-view />
    </div>
    <div v-if="!$route.meta.loginScreen">
      <div class="container-fluid">
        <Pagehead />
        <Sidebar />
        <div class="main-content">
          <router-view />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Pagehead from "./layout/header.vue";
import Sidebar from "./layout/sidebar.vue";

export default {
  name: "App",
  components: {
    Pagehead,
    Sidebar,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

.main-content {
  float: right;
  width: calc(100vw - 180px);
  padding: 15px;
}
</style>
