import services from "@/services";

import { GET_BOOKS } from "@/store/type-actions";
import { SET_BOOK } from "@/store/type-mutations";

export const book = {
  mutations: {
    [SET_BOOK](state, books) {
      state.books = books;
    },
  },
  actions: {
    async [GET_BOOKS]({ commit }) {
      try {
        let url = "/Book";
        const { data } = await services.books.getBooks(url);
        commit(SET_BOOK, data);
      } catch (error) {
        console.log(error);
      }
    },
  },
};
