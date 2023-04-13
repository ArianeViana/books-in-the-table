<template>
  <div class="modal is-active">
    <div class="modal-background"></div>
    <div class="modal-card">
      <header class="modal-card-head">
        <p class="modal-card-title">Cadastro de autor</p>
      </header>
      <section class="modal-card-body">
        <div class="field">
          <label class="label">Nome</label>
          <div class="control">
            <input class="input is-warning is-focused" type="text" placeholder="digite o nome" v-model="state.name">
          </div>
        </div>
        <div class="field">
          <label class="label">País onde nasceu</label>
          <div class="control">
            <input class="input is-warning is-focused" type="text" placeholder="digite o país" v-model="state.country">
          </div>
        </div>
      </section>
      <footer class="modal-card-foot">
        <button class="button is-success is-warning" @click="saveAuthor()">Salvar</button>
        <button class="button" @click="emitTrigger">Cancelar</button>
      </footer>
    </div>
  </div>
</template>

<script>
import { store } from '@/store';
import { CREATE_AUTHOR } from '@/store/type-actions';
import { reactive } from 'vue';
import Swal from "sweetalert2";


export default {
  methods: {
    emitTrigger() {
      this.$emit("closeModal")
    },
  },
  setup() {
    const state = reactive({
      fullName: "",
      nationality: ""

    });

    async function saveAuthor() {
      try {
        state.author = {
          fullName: state.name,
          nationality: state.country
        }
        if (!state.author.fullName) {
          Swal.fire({
            position: "center",
            icon: "error",
            iconColor: "#ffe08a",
            background: "white",
            color: "#545454",
            title: `Tente novamente.`,
            text: `"Nome" é um campo obrigatório para realizar o cadastro.`,
            showConfirmButton: false,
            timer: 3000,
          });
          return;
        }
        store.dispatch(CREATE_AUTHOR, state.author);
        Swal.fire({
          position: "center",
          icon: "success",
          iconColor: "#ffe08a",
          color: "#545454",
          background: "white",
          title: `Sucesso!`,
          text: `Autor cadastrado com sucesso!`,
          showConfirmButton: false,
          timer: 2500,
        });


      } catch (error) {
        console.log(error)
      }
    }

    return {
      saveAuthor,
      state
    }
  }
}
</script>