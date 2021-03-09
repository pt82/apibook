<template>
<div class="container edit_event">
  <h3>Редактирование события {{EVENT[0].name}}</h3>
  {{EVENT}}
  <hr>

  <b-row>
    <b-col cols="12">
      <b-form-group>
        <h6>Событие</h6>
        <b-form-input
          v-model="form.Name"
        ></b-form-input>
      </b-form-group>
    </b-col>
    <b-col cols="12">
      <b-form-group>
        <h6>Короткое описание</h6>
        <b-form-textarea
          id="textarea"
          v-model="form.SmallDesc"
          rows="3"
          max-rows="6"
        ></b-form-textarea>
      </b-form-group>
    </b-col>
  </b-row>
  <b-row>
    <b-col cols="12">
      <b-form-group>
        <h6>Полное описание</h6>
        <b-form-textarea
          id="textarea"
          v-model="form.FullDesc"
          rows="3"
          max-rows="6"
        ></b-form-textarea>
      </b-form-group>
    </b-col>
    <b-col cols="3">
      <b-form-group>
        <h6>Дата</h6>
        <datetime   v-model="form.Date"  type="date"></datetime>
      </b-form-group>
    </b-col>
  </b-row>
  <div class="mb-3">
    <b-row class="">
      <b-col cols="8"></b-col>
      <b-col cols="2" class="" >
        <b-button class="w-100" @click="cancel_event">Отмена</b-button>
      </b-col>
      <b-col cols="2">
        <b-button class="w-100 btn-success" @click="save_event">Сохранить</b-button>
      </b-col>
    </b-row>
</div>
</div>
</template>

<script>
// import { DateTime } from 'luxon'
import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'

export default {
  name: 'EventEdit',
  data () {
    return {
      eventId: this.$store.state.id_event,
      form: {
        Id: null,
        Name: '',
        SmallDesc: '',
        FullDesc: '',
        Date: null,
        UserId: null,
        active: null
      }
    }
  },
  computed: {
    ...mapGetters([
      'EVENT'
    ])
  },
  async created () {
    await this.GET_Event(this.eventId)
    this.form.Id = this.$store.state.id_event
    this.form.Name = this.EVENT[0].name
    this.form.FullDesc = this.EVENT[0].fullDesc
    this.form.SmallDesc = this.EVENT[0].smallDesc
    this.form.Date = this.EVENT[0].date
    this.form.UserId = this.$store.state.id_user
    this.form.active = true
  },
  methods: {
    ...mapActions([
      'GET_Event'

    ]),
    save_event () {
      // console.log(this.form)
      axios
        .put(`/api/Events/${this.EVENT[0].id}`, this.form)
        .then((response) => {
          if (response.status === 204) {
            this.$router.push({ path: '/user' })
            this.$alert(
              'Cобытие ' + JSON.parse(response.config.data).Name + ' успешно отредактировано!')
          }
        })
        .catch((error) => {
          console.log(error)
          return error
        })
    },
    cancel_event () {
      this.$router.push({ path: '/user' })
    }
  }
}

</script>

<style lang="scss" scoped>
 .edit_event{
   background-color: lightgray;
   border-radius: 5px;
   padding-bottom: 2rem;

   .edit_event-title {
     text-align: center;
     padding-top: 1rem;
   }
 }
</style>
