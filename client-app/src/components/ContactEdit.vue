<template>
<div class=" container edit_contact">
  <div class="edit_contact-title">
      <h3>Редактирование контакта {{CONTACT.fist_Name}} {{CONTACT.last_Name}}</h3>
    <hr>
  </div>
    <b-row>
      <b-col cols="6">
        <b-form-group>
          <h6>Фамилия</h6>
          <b-form-input
            v-model="form.Fist_Name"
          ></b-form-input>
        </b-form-group>
      </b-col>
      <b-col cols="6">
        <b-form-group>
          <h6>Имя</h6>
          <b-form-input
            v-model="form.Last_Name"
          ></b-form-input>
        </b-form-group>
      </b-col>
      </b-row>
  <b-row>
    <b-col cols="3">
      <b-form-group>
        <h6>Пол</h6>
        <b-form-select
          v-model="form.sexId"
          >
          <option v-for="item in LIST_SEXES" v-bind:value="item.id" :key="item.id">
            {{item.name}}
          </option>
        </b-form-select>
       </b-form-group>
    </b-col>
    <b-col cols="3">
      <b-form-group>
      <h6>Телефон</h6>
      <input-mask required
                  class="form-control"
                  placeholder="+7(ХХХ)ХХX-ХХ-ХХ"
                  v-model="form.Mobile_phone"
                  mask="+7(999)999-99-99"

      />
        </b-form-group>
    </b-col>
  </b-row>
  <hr>
  <b-row>
    <b-col cols="4">
      <b-form-group>
        <b-form-select
          v-model="formphone.Phone_typeId"
        >
          <option v-for="item in LIST_PHONE_TYPE" v-bind:value="item.id" :key="item.id">
            {{item.type}}
          </option>
        </b-form-select>
      </b-form-group>
    </b-col>
    <b-col cols="4">
      <b-form-group>
        <b-form-input
          v-model="formphone.Num"
        ></b-form-input>
      </b-form-group>
    </b-col>
    <b-col cols="1">
      <b-button class="btn btn-success" @click="add_phone">+</b-button>
    </b-col>
  </b-row>
  <hr>
  <div v-for="item in LIST_PHONE"
        :key="item.id">
      <b-row class="pt-2">
      <b-col cols="2"> {{item.type}} </b-col>
        <b-col cols="4"> <b-form-input  v-model=item.num></b-form-input></b-col>
        <b-col cols="2" ><b-button :id="item.id" @click="edit_phone(item)" class="btn-success"><i class="fas fa-check-circle"></i></b-button><b-button @click="del_phone(item.id)" class="btn-danger ml-2"><i  class="fas fa-trash-alt"></i></b-button></b-col>

    </b-row>
  </div>
    <hr>
  <div class="mb-3">
  <b-row class="">
    <b-col cols="8"></b-col>
    <b-col cols="2" class="" >
       <b-button class="w-100" @click="cancel_contact">Отмена</b-button>
    </b-col>
    <b-col cols="2">
      <b-button class="w-100 btn-success" @click="save_contact">Сохранить</b-button>
    </b-col>
  </b-row>
  </div>
</div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'

export default {
  name: 'ContactEdit',
  data () {
    return {
      selected: null,
      form: {
        Id: null,
        Fist_Name: null,
        Last_Name: null,
        Mobile_phone: null,
        sexId: null,
        userId: null
      },
      formphone: {
        Phone_typeId: null,
        Num: '',
        ContactId: this.$store.state.id_contact
      },
      formphoneedit: {
        id: null,
        Num: null,
        ContactId: null,
        Phone_typeId: null
      }
    }
  },
  computed: {
    ...mapGetters([
      'CONTACT',
      'LIST_SEXES',
      'LIST_PHONE_TYPE',
      'LIST_PHONE'
    ])
  },
  async created () {
    await this.GET_Contact(this.$store.state.id_contact)
    this.GET_List_Phonetype()
    this.GET_ListSex()
    this.GET_List_Phone(this.$store.state.id_contact)
    this.form.sexId = this.CONTACT.sexId
    this.form.userId = this.CONTACT.userId
    this.form.Id = this.$store.state.id_contact
    this.form.Fist_Name = this.CONTACT.fist_Name
    this.form.Last_Name = this.CONTACT.last_Name
    this.form.Mobile_phone = this.CONTACT.mobile_Phone
  },
  methods: {
    ...mapActions([
      'GET_Contact',
      'UPDATE_Contact',
      'GET_ListSex',
      'GET_List_Phonetype',
      'GET_List_Phone'
    ]),
    save_contact () {
      console.log(this.form)
      axios
        .patch(`/api/Contacts/${this.$store.state.id_contact}`, this.form)
        .then((response) => {
          // if (response.status === 204) {
          this.$router.push({ path: '/user' })
          this.$alert(
            'Контакт ' + JSON.parse(response.config.data).Fist_Name + ' успешно отредактирован!')
          // }
        })
        .catch((error) => {
          console.log(error)
          return error
        })
    },
    cancel_contact () {
      this.$router.push({ path: '/user' })
    },
    add_phone () {
      console.log(this.formphone)
      axios
        .post('/api/phone/', this.formphone)
        .then((response) => {
          this.GET_List_Phone(this.$store.state.id_contact)
          this.formphone.Num = ''
          this.formphone.Phone_typeId = null
        })
    },
    edit_phone (item) {
      this.formphoneedit.id = item.id
      this.formphoneedit.Num = item.num
      this.formphoneedit.ContactId = item.contactId
      this.formphoneedit.Phone_typeId = item.phone_typeId
      axios
        .post(`/api/phone/${item.id}`, this.formphoneedit)
        .then(responce => {
          document.getElementById(item.id).setAttribute('disabled', 'disabled')
          this.GET_List_Phone(this.$store.state.id_contact)
        })
    },
    del_phone (index) {
      axios
        .delete(`/api/phone/${index}`)
        .then(responce => {
          this.GET_List_Phone(this.$store.state.id_contact)
        })
    }
  }
}
</script>

<style lang="scss" scoped>
.edit_contact {
  background-color: lightgray;
  border-radius: 5px;
  padding-bottom: 2rem;

  .edit_contact-title {
    text-align: center;
    padding-top: 1rem;
  }
}
</style>
