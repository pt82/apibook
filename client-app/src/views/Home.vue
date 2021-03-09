<template>
  <div class="home container">
    <div>

      <b-button @click="$router.push({ path: '/logs' })" >ЛОГИ</b-button>
      <b-card no-body>
        <b-tabs pills card>
          <b-tab title="Мои контакты" active><b-card-text> <ContactsList></ContactsList></b-card-text></b-tab>
          <b-tab title="Мои события"><b-card-text> <EventsList></EventsList></b-card-text></b-tab>
        </b-tabs>
      </b-card>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Home',
  components: {
  }
}
</script>
<style scoped lang="scss">
.home{
  //margin: 5rem;
}
</style>
