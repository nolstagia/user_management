<template>
  <div class="row">
    <h3 style="text-align: left">ADD PERMISSION</h3>

    <div class="col-md-6 dis-h pad-top1">
      <label for="inputName" class="col-sm-2 lab-a">Permission name: </label>
      <div class="col-sm-8">
        <input
          class="form-control inp-a border-cus"
          v-model="permission_name"
          id="inputName"
          placeholder="Permission name"
        />
      </div>
    </div>

    <div class="col-md-6 dis-h pad-top1">
      <label for="inputScreen" class="col-sm-2 lab-a">Screen: </label>
      <div class="col-sm-8">
        <input
          class="form-control inp-a border-cus"
          v-model="Screen"
          id="inputScreen"
          placeholder="Screen"
        />
      </div>
    </div>

    <div class="col-md-12 margin-custom">
      <div class="flexx">
        <button class="btn btn-danger ml-5">Cancel</button>

        <button @click="add_permission" class="btn btn-success ml-5">
          Save
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "add_permission",

  data: () => ({
    permission_name: "",
    Screen: "",
  }),

  methods: {
    add_permission() {
      var vm = this;
      var data = {
        name: vm.permission_name,
        screen: vm.Screen,
      };
      vm.axios.post("api/Permission/CreatePermission", data);
      vm.$alert("Successfully added permission");
      vm.$router.push("/permissions");
      vm.$forceUpdate();
    },
  },
};
</script>

<style scoped>
.border-cus {
  border-radius: 6px;
  border: 1px solid #ced4d3;
}

.pad-top1 {
  padding-top: 15px;
}
.flexx {
  margin-right: 30%;
}
</style>

