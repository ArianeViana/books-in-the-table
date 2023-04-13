<template>
    <div class="search-container">
        <div class="box">
            <TheInput text="digite o nome" />
            <TheButton text="Buscar Editora" />
        </div>
        <div class="card">
            <div class="card-content" v-for="publisher in publishers" :key="publisher.id">
                <div class="media">
                    <div class="media-left">
                        <figure class="image is-98x98">
                            <img src="https://bulma.io/images/placeholders/96x96.png" alt="Placeholder image">
                        </figure>
                    </div>
                    <div class="media-content">
                        <p class="title is-4">{{ publisher.name }}</p>
                        <p class="subtitle is-6">Publicações: 5</p>
                    </div>
                </div>

                <div class="content">
                </div>
            </div>
        </div>
    </div>


</template>

<script>
import { onMounted, computed, reactive } from "vue";

import TheInput from "../components/TheInput.vue";
import TheButton from "../components/TheButton.vue";

import useStore from "../store/index"
import { GET_PUBLISHERS } from "../store/type-actions";

export default {
    components: {
        TheInput,
        TheButton
    },
    setup() {
        const store = useStore();
        const state = reactive({
            name: ""
        })

        onMounted(() => {
            store.dispatch(GET_PUBLISHERS);
        });

        const publishers = computed(() => store.state.publisher.publishers);

        return {
            publishers,
            state
        }
    }
}
</script>

<style>

</style>