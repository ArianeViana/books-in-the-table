export default (httpClient) => ({
  getAuthors: async (url) => {
    const response = await httpClient.get(url);
    return {
      data: response.data,
    };
  },

  addAuthor: async (author) => {
    const response = await httpClient.post("/Author", author);

    return {
      data: response.data,
    };
  },
});
