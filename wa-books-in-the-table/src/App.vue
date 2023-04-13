<template>
  <TheNavbar />
  <div class="container">
    <RouterView />
  </div>

</template>

<script>
import TheNavbar from "./components/TheNavbar.vue";

export default {
  components: {
    TheNavbar,
  }
}
</script>

<style>
@import "./assets/style/default.css";
@import "../node_modules/bulma/css/bulma.css";

.container {
  padding: 0rem 4rem;
}
</style>
