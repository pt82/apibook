<template>
      <div class="container logs p-4">

        <b-row>
          <b-col cols="4"><h6>С</h6></b-col>
          <b-col cols="4"><h6>ПО</h6></b-col>
        </b-row>
        <b-row>
          <b-col cols="4">
        <b-form-datepicker  v-model="form.Data_begin" class="mb-2"></b-form-datepicker>
          </b-col>
          <b-col cols="4">
          <b-form-datepicker  v-model="form.Data_end" class="mb-2"></b-form-datepicker>
          </b-col>
          <b-col cols="3">
            <button  type="button" @click="show_logs()" class="btn btn-success">Показать логи</button>
          </b-col>
        </b-row>
        <vue-ads-table-tree
    :columns="columns"
    :rows="logs"
    :page="page"
    :items-per-page="5"
  >
    <template >

    </template>
  </vue-ads-table-tree>
      </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'
// import axios from 'axios'
// import helpers from '@/helpers/helpers'
// import Swal from 'sweetalert2'
// import { bus } from '@/main'
export default {
  props: [],
  name: 'LogList',
  data () {
    return {
      form: {
        Data_begin: '',
        Data_end: ''
      },
      logs: [],
      page: 0,
      columns: [
        {
          property: 'name',
          title: 'Событие'
        },
        {
          property: 'login',
          title: 'Имя Пользователя'
        },
        {
          property: 'date',
          title: 'Дата'
        }
      ]
    }
  },
  computed: {
    ...mapGetters([
      'LIST_LOGS'

    ])
  },
  created () {
    // this.GET_ListLogs()
  },
  methods: {
    ...mapActions([
      'GET_ListLogs'
    ]),
    show_logs () {
      console.log(this.form)
      axios
        .post('/api/viewlog', this.form)
        .then(responce => {
          this.logs = responce.data
        })
    }
  }
}
</script>
<style scoped lang="scss">
.logs {
background-color: lightgrey;
}
</style>
