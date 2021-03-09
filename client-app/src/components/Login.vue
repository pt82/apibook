<template>
  <div>
    <b-spinner class="spinner"  variant="danger" v-if="spinnner" label="Loading..."></b-spinner>
<div class="login">
  <div class="mt-3 ml-3">Авторизация</div>
  <hr>
  <div class="ml-5 mr-5">
  <b-form-group>
    <div class="d-inline-flex w-100">
    <i class="fas fa-user mt-2 mr-2"></i>
    <b-form-input  type="text" v-model="formlogin.email" placeholder="user@email.ru"></b-form-input>
    </div>
  </b-form-group>
  <b-form-group>
    <div class="d-inline-flex w-100">
      <i class="fas fa-key mt-2 mr-2"></i>
    <b-form-input type="password" v-model="formlogin.Password" placeholder="Пароль"></b-form-input>
    </div>
  </b-form-group>
    <div><b-alert v-if="error.login_fields" variant="danger" show>Заполните все поля</b-alert></div>
    <div><b-alert v-if="error.login" variant="danger" show>Не верный логин или пароль</b-alert></div>
    <b-form-group class="">
      <b-button class="ml-5  btn btn-success w-75" @click="login">Вход</b-button>
    </b-form-group>
    <div class="d-flex justify-content-center mb-2 reg">
    <div data-toggle="modal" data-target="#ContactModal">Регистрация </div>
    </div>
  </div>

<!--  мод окно регистрация-->

  <div>
    <div class="modal fade" id="ContactModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-body">
            <b-form-group>
              <h6>Имя</h6>
              <b-form-input
                v-model="form.login"
              ></b-form-input>
            </b-form-group>
            <b-form-group>
              <h6>Электронная почта</h6>
              <b-form-input
                type="email"
                v-model="form.email"
              ></b-form-input>
              </b-form-group>
            <b-form-group>
              <h6>Пароль</h6>
              <b-form-input
                v-model="form.Password"
                type="password"
              ></b-form-input>
              </b-form-group>
              <b-form-group>
              <h6>Повторите пароль</h6>
              <b-form-input
                type="password"
                v-model="form.password_confirmation"
              ></b-form-input>
                <div><b-alert v-if="error.password" variant="danger" show>Пароли не совпадают!</b-alert></div>
            </b-form-group>
            <div><b-alert v-if="error.fields" variant="danger" show>Заполните все поля</b-alert></div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">Отмена</button>
              <button @click="onRegister"  type="button"  class="btn btn-success">Зарегистрироваться</button>

            </div>
          </div>
        </div>
      </div>
    </div>

  </div>
</div>
  </div>
</template>

<script>
import { mapGetters, mapState } from 'vuex'
import axios from 'axios'
import helpers from '@/helpers/helpers'
import Swal from 'sweetalert2'
// import { bus } from '@/main'
export default {
  props: [],
  name: 'Login',
  data () {
    return {
      spinnner: false,
      error: {
        fields: false,
        password: false,
        login: false,
        login_fields: false
      },
      form: {
        login: null,
        Password: null,
        password_confirmation: null,
        Token: '0',
        email: null
      },
      formlogin: {
        email: null,
        Password: null
      }
    }
  },
  computed: {
    ...mapState([

    ]),
    ...mapGetters([

    ])
  },
  mounted () {

  },
  methods: {
    login () {
      this.error.login_fields = false
      if (this.formlogin.email === null || this.formlogin.Password === null) {
        this.error.login_fields = true
        return
      }
      axios
        .post('api/users/login', this.formlogin)
        .then(response => {
          // console.log(response)
          // if (response.ok === true) {
          //   console.log(response.json())
          //   this.error.login = true
          // } else {
          //   console.log('333')
          //   console.log(response)
          // }
          if (response.status === 400) {
            this.error.login = true
            return false
          }
          this.$store.state.id_user = response.data.id
          this.$router.push({ path: '/user' })
        })
    },
    onRegister () {
      this.error.password = false
      this.error.fields = false
      if (this.form.name === null || this.form.Password === null || this.form.email === null || this.form.password_confirmation === null) {
        this.error.fields = true
        return false
      }
      if (this.form.Password !== this.form.password_confirmation) {
        this.error.password = true
        return false
      }
      this.spinnner = true
      axios
        .post('/api/Users', this.form)
        .then(response => {
          this.spinnner = false
          helpers.closeModal()
          if (response.status === 201) {
            this.form.password_confirmation = null
            this.form.password = null
            this.form.login = null
            this.form.email = null
            this.$alert('Пользователь' + JSON.parse(response.config.data).login + ' успешно зарегистрирован! ' + 'На почту ' + JSON.parse(response.config.data).email + ' отправлено письмо! ')
            for (const item in this.error) {
              this.error[item] = false
            }
          }
        })
        .catch(error => {
          this.spinnner = false
          if (error.response.status === 400) {
            this.spinnner = false
            Swal.fire({
              icon: 'error',
              title: 'Упс...',
              text: 'Пользователь с данной эл. почтой уже зарегистрирован!'
            })
            return false
          }
          if (error.response.status === 500) {
            this.spinnner = false
            Swal.fire({
              icon: 'error',
              title: 'Упс...',
              text: 'Невозможно отправить письмо на указанный адрес!'
            })
            return false
          }
        })
    }
  }
}
</script>

<style lang="scss" scoped>
.spinner{
  z-index: 10000000;
  position: absolute;
  top: 30%;
  left: 50%;
}
.login{
  position: absolute;
  left: 35%;
  top: 20%;
  width: 450px;
  border-radius: 10px;
  border: double 6px grey;
  background-color: lightblue;
 .reg:hover {
   cursor: pointer;
   color: red;
 }
  .name{
    //width: 200px !important;
  }
  .pass{
    width: 80% !important;
  }
}
</style>
