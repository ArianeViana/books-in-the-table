<template>
    <div class="card">
        <div class="card-content">
            <div class="media">
                <div class="media-left">
                    <figure class="image is-128x128">
                        <img src="../assets/img/usuario.png" alt="Placeholder image">
                    </figure>
                </div>
                <div class="media-content">
                    <p class="title is-4">{{ author }}</p>
                    <p class="subtitle is-6"></p>
                </div>
            </div>
            <div class="content">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                Phasellus nec iaculis mauris. <a>@bulmaio</a>.
                <a href="#">#css</a> <a href="#">#responsive</a>
                <br>
                <time datetime="2016-1-1">11:09 PM - 1 Jan 2016</time>
            </div>
        </div>
    </div>
</template>

<script>
import { onMounted, computed } from "vue";
import useStore from "../store/index"
import { FIND_AUTHOR_BY_ID } from "../store/type-actions"
import { useRoute } from 'vue-router'


export default {
    setup() {
        const route = useRoute();
        const store = useStore();

        onMounted(() => {
            store.dispatch(FIND_AUTHOR_BY_ID, route.params.id);
        });

        const author = computed(() => store.state.author.selectedAuthor)

        return {
            author,
        }
    }
}
</script>

<style scoped>
.card {
    margin-top: 50px;
}
</style>
