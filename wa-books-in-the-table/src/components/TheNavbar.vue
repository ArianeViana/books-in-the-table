<template>
    <nav class="navbar is-warning" role="navigation" aria-label="main navigation">
        <div class="navbar-brand">
            <a class="navbar-item" href="">
                <img src="../assets/img/logobooks.png" width="112" height="28">
            </a>

            <a role="button" class="navbar-burger" aria-label="menu" aria-expanded="false"
                data-target="navbarBasicExample" @click="toggleMenu">
                <span aria-hidden="true"></span>
                <span aria-hidden="true"></span>
                <span aria-hidden="true"></span>
            </a>
        </div>

        <div id="navbarBasicExample" class="navbar-menu">
            <div class="navbar-start">
                <RouterLink to="/autores" class="navbar-item" @click="getAuthors">
                    Autores
                </RouterLink>
                <RouterLink to="/editoras" class="navbar-item">
                    Editoras
                </RouterLink>
                <RouterLink to="/livros" class="navbar-item">
                    Livros
                </RouterLink>
            </div>

            <div class="navbar-end">
                <div class="navbar-item has-dropdown is-hoverable">
                    <a class="navbar-link">
                        <img src="../assets/img/usuario.png" width="28" height="28">
                    </a>
                    <div class="navbar-dropdown is-right">
                        <a class="navbar-item">
                            Meu Perfil
                        </a>
                        <a class="navbar-item">
                            Minha Estante
                        </a>
                        <a class="navbar-item">
                            Configurações
                        </a>
                        <hr class="navbar-divider">
                        <a class="navbar-item">
                            Sair
                        </a>
                    </div>
                </div>

            </div>
        </div>
    </nav>
</template>

<script>
import useStore from "../store/index"
import { GET_AUTHORS } from "../store/type-actions";

export default {
    methods: {
        toggleMenu() {
            let dropMenu = document.getElementById("navbarBasicExample");
            dropMenu.classList.toggle("is-active");
        }
    },
    //após uma pesquisa ao clicar na aba de autor não aparece os autores cadastrados
    //verificar dps uma melhor solução para o problema
    setup() {
        const store = useStore();

        function getAuthors() {
            store.dispatch(GET_AUTHORS)
        }

        return {
            getAuthors
        }

    }
}
</script>