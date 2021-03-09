import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import ContactEdit from '@/components/ContactEdit'
import Autorization from '../views/Autorization.vue'
import Login from '@/components/Login'
import EventEdit from '@/components/EventEdit'
import LogList from '@/components/LogList'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Autorization',
    component: Login
  },
  {
    path: '/Edit/:id',
    name: 'EditContact',
    component: ContactEdit
  },
  {
    path: '/edit_event/:id',
    name: 'EditEvent',
    component: EventEdit
  },
  {
    path: '/login',
    name: 'Autorization',
    component: Autorization
  },
  {
    path: '/user',
    name: 'Home',
    component: Home
  },
  {
    path: '/logs',
    name: 'Loglist',
    component: LogList
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
