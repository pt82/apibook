<template>
<div>

  <b-button type="button" class="btn btn-success"  @click="show_mod" data-toggle="modal" data-target="#EventModal">Добавить</b-button>
<!--мод окно добавления события-->
  <div class="modal fade" id="EventModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <b-form-group>
            <h6>Событие</h6>
            <b-form-input
              v-model="form.Name"
            ></b-form-input>
            <hr>
            <h6>Краткое описание</h6>
            <b-form-input
              v-model="form.SmallDesc"
            ></b-form-input>
            <hr>
            <h6>Полное описание</h6>
            <b-form-input
              v-model="form.FullDesc"
            ></b-form-input>
            <hr>
            <h6>Дата события</h6>
            <datetime   v-model="form.Date"  type="date"></datetime>
            </b-form-group>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Отмена</button>
            <button  type="button" @click="add_event()" class="btn btn-success">Добавить</button>
          </div>
        </div>
      </div>
    </div>
  </div>

  <vue-ads-table-tree
    :columns="columns"
    :rows="LIST_EVENT"
    :page="page"
    :items-per-page="5"
  >
    <template slot="id"  slot-scope="props" class="">
      <b-button @click="edit(props.row.id)" class="w-25  btn-info ml-5" > Редактировать </b-button>
      <b-button type="button" @click=" del_event(props.row.id)"  class="w-25  btn-danger ml-5">Удалить</b-button>
    </template>
  </vue-ads-table-tree>
</div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'
import helpers from '@/helpers/helpers'
import Swal from 'sweetalert2'

export default {
  name: 'EventsList',
  data () {
    return {
      form: {
        userId: this.$store.state.id_user,
        Name: '',
        SmallDesc: '',
        FullDesc: '',
        Date: null
      },
      id_user: this.$store.state.id_user,
      page: 0,
      columns: [
        {
          property: 'name',
          title: 'Событие'
        },
        {
          property: 'date',
          title: 'Дата'
        },
        {
          property: 'smallDesc',
          title: 'Описание'
        },
        {
          property: 'id',
          title: ''
        }
      ]
    }
  },
  computed: {
    ...mapGetters([
      'LIST_EVENT'

    ])
  },
  created () {
    this.GET_ListEvents(this.id_user)
  },
  methods: {
    ...mapActions([
      'GET_ListEvents'
    ]),
    add_event () {
      axios
        // { Fist_Name: this.form.Fist_Name, Last_Name: this.form.List_Name }
        .post('/api/events/', this.form)
        .then(response => {
          this.GET_ListContacts(this.$store.state.id_user)
          helpers.closeModal()
        })
        .catch(error => {
          this.errors = error.response.data.errors
        })
    },
    edit (index) {
      this.$store.state.id_event = index
      this.$router.push({ path: '/edit_event/' + index })
    },
    del_event (index) {
      Swal.fire({
        title: 'Вы уверены?',
        text: 'Запись удалится безвозвратно!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Да, удалить',
        cancelButtonText: 'Отмена'
      }).then((result) => {
        if (result.isConfirmed) {
          Swal.fire(
            'Удалено!',
            '',
            'success'
          )
          axios
            .delete(`/api/events/${index}`)
            .then(response => {
              this.GET_ListEvents(this.$store.state.id_user)
            })
        }
      })
    },
    show_mod () {}
  }
}
</script>

<style scoped>

</style>
