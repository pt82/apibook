<template>
<div >

 <b-button type="button" class="btn btn-success"  @click="show_modal" data-toggle="modal" data-target="#ContactModal">Добавить</b-button>

  <!--мод окно доб контакта-->
  <div class="modal fade" id="ContactModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <b-form-group>
            <h6>Фамилия*</h6>
            <b-form-input
              v-model="form.Fist_Name"
            ></b-form-input>
            </b-form-group>
          <b-form-group>
            <h6>Имя</h6>
            <b-form-input
              v-model="form.Last_Name"
            ></b-form-input>
            </b-form-group>
          <b-form-group>
            <h6>Пол</h6>
            <b-form-select
              v-model="form.sexId"
              required
            >
              <option v-for="item in LIST_SEXES" v-bind:value="item.id" :key="item.id">
                {{item.name}}
              </option>
            </b-form-select>
            <b-button @click="clearSex">X</b-button>
            </b-form-group>
          <b-form-group>
            <h6>Телефон*</h6>
            <input-mask required
                        class="form-control"
                        placeholder="+7(ХХХ)ХХX-ХХ-ХХ"
                        v-model="form.Mobile_Phone"
                        mask="+7(999)999-99-99"

            />
            <div>  <b-alert v-if="error_phone" variant="danger" show>Укажите телефон в правильном формате</b-alert></div>
            </b-form-group>
        <div><b-alert v-if="error" variant="danger" show>Заполните все обязательные поля</b-alert></div>
<!--            <h6>Фото</h6>-->
<!--            <b-form-file-->
<!--              v-model="file"-->
<!--              @change="onAttachmentChange"-->
<!--              ref="profileimage"-->
<!--              placeholder="Выберите файл..."-->
<!--              drop-placeholder="Файл выбран..."-->
<!--              browse-text="Обзор..."-->
<!--            ></b-form-file>-->
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Отмена</button>
            <button  type="button" @click="add_contact()" v-show="button_contact_visible" class="btn btn-success">Добавить</button>
          </div>
        </div>
      </div>
    </div>
  </div>

  <vue-ads-table-tree
    :columns="columns"
    :rows="LIST"
    :page="page"
    @page-change="pageChanged"
    @filter-change="filterChanged"
    :items-per-page="5"
>
    <template slot="id"  slot-scope="props">
      <b-button @click="edit(props.row.id)" class="w-25 ml-3 btn-warning" > <i class="fas fa-pencil-alt "></i></b-button>
      <b-button type="button" @click="delcontact(props.row.id)"  class="w-25 ml-3  btn-danger"><i class="far fa-trash-alt"  ></i> </b-button>
    </template>
  </vue-ads-table-tree>
</div>
</template>

<script>

import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'
import helpers from '@/helpers/helpers'
import Swal from 'sweetalert2'
// import { bus } from '@/main'

export default {
  name: 'ContactsList',

  data () {
    return {
      error_phone: false,
      error: false,
      button_contact_visible: true,
      category: [],
      file: null,
      attachment: null,
      form: {
        userId: this.$store.state.id_user,
        sexId: null,
        Last_Name: null,
        Fist_Name: null,
        Mobile_Phone: null
        // Sex: null
        // work_phone: null,
        // desc: ''
      },
      page: 0,
      columns: [
        {
          property: 'fist_Name',
          title: 'Фамилия',
          filterable: true
        },
        {
          property: 'last_Name',
          title: 'Имя',
          filterable: true
        },
        {
          property: 'mobile_Phone',
          title: 'Телефон',
          filterable: true
        },
        {
          property: 'sex',
          title: 'Пол',
          filterable: true
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
      'LIST',
      'LIST_EVENT',
      'LIST_SEXES'
    ])
  },
  created () {
    // this.GET_ListContacts(1)
    // bus.$on('id_user', data => (this.GET_ListContacts(data)))
    // bus.$on('id_user', data => { console.log(data) })
    // bus.$on('id_user', data => { this.GET_ListContacts(1) })
    this.GET_ListContacts(this.$store.state.id_user)
    // this.GET_ListEvents(this.$store.state.id_user)

  },
  methods: {
    ...mapActions([
      'GET_ListContacts',
      'GET_ListSex'
    ]),
    pageChanged (page) {
      this.page = page
    },
    filterChanged (filter) {
      this.filter = filter
    },
    show_modal () {
      this.form.Fist_Name = ''
      this.form.Last_Name = ''
      this.form.Mobile_Phone = null
      this.form.sexId = 3
    },
    clearSex() {
      this.form.sexId=3
    },
    add_contact () {
      console.log(this.form)
      // const data = new FormData()
      // for (const i in this.form) {
      //   data.append(i, this.form[i])
      // }
      // if (this.attachment) {
      //   const file = this.attachment
      //   data.append('fileimage', file)
      // }
      if (this.form.Mobile_Phone === null || this.form.Fist_Name === null) {
        this.error = true
        return
      }
      if (this.form.Mobile_Phone.includes('_')) {
        this.error_phone = true
        return false
      }
      axios
        // { Fist_Name: this.form.Fist_Name, Last_Name: this.form.List_Name }
        .post('/api/contacts/', this.form)
        .then(response => {
          this.GET_ListContacts(this.$store.state.id_user)
          helpers.closeModal()
          this.error = false
          this.error_phone = false
        })
        .catch(error => {
          this.errors = error.response.data.errors
        })
    },
    edit (index) {
      this.$store.state.id_contact = index
      this.$router.push({ path: '/edit/' + index })
    },
    delcontact (index) {
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
            .delete(`/api/contacts/${index}`)
            .then(response => {
              this.GET_ListContacts(this.$store.state.id_user)
            })
        }
      })
    },
    onAttachmentChange (e) {
      this.attachment = e.target.files[0]
    }
  }
}
</script>

<style scoped>

</style>
