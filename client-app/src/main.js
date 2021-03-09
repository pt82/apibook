import Vue from 'vue'
import App from './App.vue'
import Vuex from 'vuex'
import router from './router'
import store from './store'
import axios from 'axios'
import ContactsList from '@/components/ContactsList'
import EventsList from '@/components/EventsList'
import VueAdsTableTree from 'vue-ads-table-tree'
import 'vue-ads-table-tree/dist/vue-ads-table-tree.css'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

// Import Bootstrap an BootstrapVue CSS files (order is important)
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import InputMask from 'vue-input-mask'

import Login from '@/components/Login'

import VueSweetalert2 from 'vue-sweetalert2'
import VueSimpleAlert from 'vue-simple-alert'

import Datetime from 'vue-datetime'
import 'vue-datetime/dist/vue-datetime.css'
import LogList from '@/components/LogList'
Vue.component('datetime', Datetime)
Vue.use(Datetime)

const options = {
  confirmButtonColor: '#41b882',
  cancelButtonColor: '#ff7674'
}
Vue.use(VueSweetalert2, options)
Vue.use(VueSimpleAlert)

Vue.component('input-mask', InputMask)
// Make BootstrapVue available throughout your project
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)
Vue.component('vue-ads-table-tree', VueAdsTableTree)
Vue.component('ContactsList', ContactsList)
Vue.component('EventsList', EventsList)
Vue.component('Login', Login)
Vue.component('LogList', LogList)

Vue.prototype.axios = axios
Vue.use(Vuex)

Vue.config.productionTip = false
// export const bus = new Vue()

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')



