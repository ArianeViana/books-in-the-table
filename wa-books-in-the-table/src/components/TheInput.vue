<template>
    <div class="input-size">
        <input class="input is-warning is-focused" type="text" :placeholder="text" @change="emitTrigger"
            v-model="textInput" />
    </div>
</template>

<script>

export default {
    props: {
        text: {
            type: String,
            required: true
        }
    },
    methods: {
        emitTrigger() {
            this.$emit("inputChange", this.textInput)

        }
    },
    data() {
        return {
            textInput: ""
        }
    }
}

</script>
<style>
.input-size {
    width: 50%;
    margin-right: 15px;
}
</style>
