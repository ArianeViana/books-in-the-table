import services from "../../../services";

import {
  GET_AUTHORS,
  FIND_AUTHOR,
  CREATE_AUTHOR,
  FIND_AUTHOR_BY_ID,
} from "../../type-actions";
import { ADD_AUTHOR, SET_AUTHOR, SELECTED_AUTHOR } from "../../type-mutations";

export const author = {
  mutations: {
    [SET_AUTHOR](state, authors) {
      state.authors = authors;
    },
    [SELECTED_AUTHOR](state, author) {
      state.selectedAuthor = author;
    },
    [ADD_AUTHOR](state, authors) {
      state.authors = authors;
    },
  },
  actions: {
    async [GET_AUTHORS]({ commit }) {
      try {
        let url = "/Authors";
        const { data } = await services.authors.getAuthors(url);
        commit(SET_AUTHOR, data);
      } catch (error) {
        console.log(error);
      }
    },
    async [FIND_AUTHOR]({ commit }, name) {
      try {
        let url = `/AuthorName/${name}`;
        const { data } = await services.authors.getAuthors(url);
        commit(SET_AUTHOR, data);
      } catch (error) {
        console.log(error);
      }
    },
    async [FIND_AUTHOR_BY_ID]({ commit }, id) {
      try {
        let url = `/Author/${id}`;
        const { data } = await services.authors.getAuthors(url);
        console.log(data);
        commit(SELECTED_AUTHOR, data);
      } catch (error) {
        console.log(error);
      }
    },
    async [CREATE_AUTHOR]({ commit }, author) {
      try {
        const { data } = await services.authors.addAuthor(author);
        commit(ADD_AUTHOR, author);
        return data;
      } catch (error) {
        console.log(error);
      }
    },
  },
};
