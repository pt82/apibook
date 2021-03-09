<template>
  <div id="app">
     <div id="nav">

    </div>
    <router-view/>
  </div>
</template>

<style lang="scss">
#app {
  height: 100vh;
  background: linear-gradient(to bottom, #4682B4 0%, #5F9EA0 100%);
}
.logo{
  margin-left: 2rem;
  margin-top: 2rem;
  width: 100px;
  height: 100px;
}
#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
