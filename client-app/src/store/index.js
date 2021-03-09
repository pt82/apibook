import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import createPersistedState from 'vuex-persistedstate'
Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    listcontact: [],
    contact: [],
    id_contact: null,
    id_event: null,
    listsexes: [],
    sex: [],
    listevents: [],
    event: [],
    id_user: [],
    listlogs: [],
    listphone: [],
    listphonetype: []

  },
  mutations: {
    SET_ListContacts (state, contacts) {
      state.listcontact = contacts
    },
    SET_ListEvents (state, events) {
      state.listevents = events
    },
    SET_Contact (state, contact) {
      state.contact = contact
    },
    SET_Event (state, event) {
      state.event = event
    },
    SET_ListSex (state, sexes) {
      state.listsexes = sexes
    },
    SET_ListLogs (state, logs) {
      state.listlogs = logs
    },
    SET_List_Phone (state, phone) {
      state.listphone = phone
    },
    SET_List_Phonetype (state, phonetype) {
      state.listphonetype = phonetype
    }
  },
  actions: {
    GET_ListContacts ({ commit }, index) {
      return axios
        .get(`/api/Usercontact/${index}`)
        .then((response) => {
          console.log(response.data)
          commit('SET_ListContacts', response.data)
          return response
        })
        .catch((error) => {
          console.log(error)
          return error
        })
    },
    GET_ListEvents ({ commit }, index) {
      return axios
        .get(`/api/UserEvent/${index}`)
        .then((response) => {
          console.log(response.data)
          commit('SET_ListEvents', response.data)

          return response
        })
        .catch((error) => {
          console.log(error)
          return error
        })
    },
    GET_Contact ({ commit }, index) {
      return axios
        .get(`/api/Contacts/${index}`)
        .then((response) => {
          commit('SET_Contact', response.data)
          return response
        })
        .catch((error) => {
          console.log(error)
          return error
        })
    },
    UPDATE_Contact ({ commit }, index, form) {
      return axios
        .put(`/api/Contacts/${index}`, form)
        .then((response) => {

        })
        .catch((error) => {
          console.log(error)
          return error
        })
    },
    GET_Event ({ commit }, index) {
      return axios
        .get(`/api/Events/${index}`)
        .then((response) => {
          commit('SET_Event', response.data)
          return response
        })
        .catch((error) => {
          console.log(error)
          return error
        })
    },
    UPDATE_Event ({ commit }, index, form) {
      return axios
        .put(`/api/Events/${index}`, form)
        .then((response) => {

        })
        .catch((error) => {
          console.log(error)
          return error
        })
    },

    GET_ListSex ({ commit }) {
      return axios
        .get('/api/sexes')
        .then((response) => {
          commit('SET_ListSex', response.data)
          console.log(response.data)
          return response
        })
        .catch((error) => {
          console.log(error)
          return error
        })
    },
    GET_ListLogs ({ commit }) {
      return axios
        .get('/api/viewlog')
        .then((response) => {
          commit('SET_ListLogs', response.data)
          console.log(response.data)
          return response
        })
        .catch((error) => {
          console.log(error)
          return error
        })
    },
    GET_List_Phonetype ({ commit }) {
      return axios
        .get('/api/phonetype/')
        .then((response) => {
          commit('SET_List_Phonetype', response.data)
          return response
        })
        .catch((error) => {
          console.log(error)
          return error
        })
    },
    GET_List_Phone ({ commit }, index) {
      return axios
        .get(`/api/phone/${index}`)
        .then((response) => {
          commit('SET_List_Phone', response.data)
          return response
        })
        .catch((error) => {
          console.log(error)
          return error
        })
    }
  },
  getters: {
    LIST (state) {
      return state.listcontact
    },
    LIST_EVENT (state) {
      return state.listevents
    },
    CONTACT (state) {
      return state.contact
    },
    EVENT (state) {
      return state.event
    },
    LIST_SEXES (state) {
      return state.listsexes
    },
    LIST_LOGS (state) {
      return state.listlogs
    },
    LIST_PHONE (state) {
      return state.listphone
    },
    LIST_PHONE_TYPE (state) {
      return state.listphonetype
    }
  },
  modules: {
  },
  plugins: [createPersistedState()]
})
