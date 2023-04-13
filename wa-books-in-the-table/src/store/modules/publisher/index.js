import services from "../../../services";

import { GET_PUBLISHERS } from "../../type-actions";
import { SET_PUBLISHER } from "../../type-mutations";

export const publisher = {
  mutations: {
    [SET_PUBLISHER](state, publishers) {
      state.publishers = publishers;
    },
  },
  actions: {
    async [GET_PUBLISHERS]({ commit }) {
      try {
        let url = "/Publisher";
        const { data } = await services.publishers.getPublishers(url);
        commit(SET_PUBLISHER, data);
      } catch (error) {
        console.log(error);
      }
    },
  },
};
