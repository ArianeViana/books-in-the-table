<template>
    <div class="search-container">
        <div class="box">
            <TheInput text="digite o nome" @input-change="inputAuthorName" />
            <TheButton text="Buscar Autor" @click="findAuthor" />
        </div>
        <div class="card" v-if="authors.length > 0">
            <div class="card-content" v-for="author in authors" :key="author.id">
                <div class="media">
                    <div class="media-left">
                        <figure class="image is-98x98">
                            <img src="https://bulma.io/images/placeholders/96x96.png" alt="Placeholder image">
                        </figure>
                    </div>
                    <div class="media-content">
                        <RouterLink :to="`/autor/${author.id}`">
                            <p class="title is-4">{{ author.fullName }}</p>
                        </RouterLink>
                        <p class="subtitle is-6">{{ author.nationality }}</p>
                        <p class="subtitle is-6">Publicações: 5</p>

                    </div>
                </div>

                <div class="content">
                </div>
            </div>
        </div>
        <div class="not-found" v-else>
            <br>
            <p>Autor não encontrado. </p>
            <p>Deseja cadastrar um novo autor? </p>
            <br>
            <TheButton text="Cadastrar Autor" @click="openingModal" />
            <AuthorModal v-if="openModal" @close-modal="closingModal" />
        </div>
    </div>
</template>

<script>
import { onMounted, computed, reactive } from "vue";

import TheInput from "../components/TheInput.vue";
import TheButton from "../components/TheButton.vue";
import AuthorModal from "../components/AuthorModal.vue";

import useStore from "../store/index"
import { GET_AUTHORS, FIND_AUTHOR } from "../store/type-actions";

export default {
    components: {
        TheInput,
        TheButton,
        AuthorModal
    },
    data() {
        return {
            openModal: false,
        }
    },
    methods: {
        openingModal() {
            this.openModal = true
        },
        closingModal() {
            this.openModal = false
        },

    },

    setup() {
        const store = useStore();
        const state = reactive({
            searchedAuthor: ""
        })

        onMounted(() => {
            store.dispatch(GET_AUTHORS);
        });

        const authors = computed(() => store.state.author.authors);

        function findAuthor() {
            store.dispatch(FIND_AUTHOR, state.searchedAuthor);
        }

        function inputAuthorName(name) {
            state.searchedAuthor = name;
        }


        return {
            authors,
            state,
            findAuthor,
            inputAuthorName,

        }
    }
}
</script>

<style>

</style>

