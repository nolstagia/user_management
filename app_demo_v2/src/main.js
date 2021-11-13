import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router';
import routes from './routers.js'
import Vuelidate from 'vuelidate'
import axios from 'axios'
import VueAxios from 'vue-axios'
import VueSimpleAlert from "vue-simple-alert";
import moment from 'moment'
import VueMoment from 'vue-moment'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faBars, faBell, faCog, faCogs, faFileExcel, faInfo, faList, faPencilAlt, faSearch, faTachometerAlt, faTrash } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'


axios.defaults.baseURL = 'http://localhost:43159'

library.add(faPencilAlt, faFileExcel, faSearch, faBell, faBars, faTachometerAlt, faList, faCog, faCogs, faInfo, faTrash)

Vue.component('font-awesome-icon', FontAwesomeIcon)


Vue.config.productionTip = false

import { BootstrapVue, BootstrapVueIcons } from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
Vue.use(BootstrapVue);
Vue.use(BootstrapVueIcons)

import './assets/css/style.css'

Vue.use(VueMoment, moment)
Vue.use(Vuelidate);
Vue.use(VueRouter);
Vue.use(VueAxios, axios);
Vue.use(VueSimpleAlert);
Vue.filter('formatDate', function(value) {
  if (value) {
    return moment(String(value)).format('DD/MM/YYYY')
  }
});


new Vue({
  router: routes,
  render: h => h(App),
}).$mount('#app')


