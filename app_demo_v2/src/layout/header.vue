<template>
  <div>
    <nav class="navbar navbar-expand-lg navbar-light">
      <div class="container-fluid" style="height: inherit">
        <div class="navbar-brand text-white" href="/">
          Administrator
        </div>
        <!-- <div class="box-search">
          <input type="text" placeholder="Search..." />
        </div> -->

        <div style="height: inherit; float: right"  >
          <div class="dropdown nav-item1" style="height: inherit; padding: 0px">
            <b-dropdown variant="primary" style="height: inherit">
              <template #button-content>
                <a
                  class="nav-link text-white"
                  style="padding: 0px; display: inline-block"
                >
                  <img
                    id="ava-img"
                    class="img-fluid ava"
                    src="@/assets/image/avatar.jpg"
                    style="border-radius: 31px"
                    alt="Avatar"
                  />
                  <span class="d-inline-block d-lg-none d-xl-inline-block">
                    <span class="text-90" id="id-user-welcome">Welcome,</span>
                    <span class="nav-user-name">Admin</span>
                  </span>
                </a>
              </template>
              <b-dropdown-item href="#"
                ><b-icon icon="person-fill" variant="primary"></b-icon>
                Profile</b-dropdown-item
              >
              <b-dropdown-item href="#"
                ><b-icon icon="tools" variant="success"></b-icon>
                Settings</b-dropdown-item
              >
              <b-dropdown-divider></b-dropdown-divider>
              <b-dropdown-item href="#"
                ><b-icon icon="arrow-return-left" variant="warning"></b-icon>
                Logout</b-dropdown-item
              >
            </b-dropdown>
          </div>
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
export default {
  name: "pagehead",
};
</script>

<style> 
.navbar-brand{
  width: 177px;
  background-color: #2166ac;
  margin:0px;
  height: inherit;
  padding-top: 15px;
  font-size: 24px;
  line-height: 54px;
  text-align: center;
}

.ava {
  height: inherit;
  position: relative;
  top: -14px;
}

.navbar-inner {
  height: inherit;
  width: 100%;
  display: -ms-flexbox;
  display: flex;
  -ms-flex-pack: justify;
  justify-content: space-between;
  background-color: inherit;
  visibility: visible;
}

.nav-item {
  height: inherit;
  border-left: 1.5px solid #1d5fa1;
  padding-top: 12px;
}

.nav-item1 {
  height: inherit;
  border-left: 1.5px solid #1d5fa1;
  padding-top: 0px;
  padding-left: 50px;
}


.box-search input {
  width: 334px;
  height: 64px;
  background: #2470bd;
  border: none;
  font-size: 14pt;
  float: left;
  color: #fff;
  padding-left: 45px;
  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  border-radius: 5px;
}

.box {
  margin: none;
  width: 350px;
  height: 64px;
}

nav {
  height: 64px;
  background-color: #2470bd;
}

.icon-1 {
  margin-left: 17px;
  margin-right: 17px;
  margin-top: 12px;
  z-index: 1;
  color: white;
  size: 20px;
}

.user-inf {
  height: inherit;
  border-left: 1px solid #0d57cc;
  padding-left: 17px;
  padding-right: 17px;
}
.d-inline-block {
  display: inline-block;
}

.text-90 {
  font-size: 0.9em !important;
}

.navbar .nav-user-name {
  display: block;
  max-width: 100px;
  text-overflow: ellipsis;
  white-space: nowrap;
  overflow: hidden;
}

.dropdown-toggle::after {
  color: white;
}
.navbar-blue .navbar-intro {
    background-color: #2166ac;
}

</style>