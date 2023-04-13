import { createStore, useStore as vuexUseStore } from "vuex";

import { author } from "./modules/author";
import { publisher } from "./modules/publisher";
import { book } from "./modules/book";

export const store = createStore({
  state: {
    author: {
      authors: [],
      selectedAuthor: {},
    },
    publisher: {
      publishers: [],
    },
    book: {
      books: [],
    },
  },
  modules: {
    author,
    publisher,
    book,
  },
});

export default function useStore() {
  return vuexUseStore();
}
