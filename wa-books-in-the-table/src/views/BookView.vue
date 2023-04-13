<template>
    <div class="search-container">
        <div class="box">
            <TheInput text="digite o título" />
            <TheButton text="Buscar Livro" />
        </div>
        <div class="card">
            <div class="card-content" v-for="book in books" :key="book.id">
                <div class="media">
                    <div class="media-left">
                        <figure class="image is-98x98">
                            <img src="https://bulma.io/images/placeholders/96x96.png" alt="Placeholder image">
                        </figure>
                    </div>
                    <div class="media-content">
                        <p class="title is-4">{{ book.title }}</p>
                        <p class="subtitle is-6">{{ book.author.fullName }}</p>
                        <p class="subtitle is-6">Editora: {{ book.publisher.name }}</p>

                    </div>
                </div>

                <div class="content">
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { onMounted, computed } from "vue";

import TheInput from "../components/TheInput.vue";
import TheButton from "../components/TheButton.vue";

import useStore from "../store/index"
import { GET_BOOKS } from "../store/type-actions";
export default {
    components: {
        TheInput,
        TheButton
    },
    setup() {
        const store = useStore();

        onMounted(() => {
            store.dispatch(GET_BOOKS);
        })

        const books = computed(() => store.state.book.books);

        return { books }

    }
}
</script>