export default (httpClient) => ({
  getBooks: async (url) => {
    const response = await httpClient.get(url);
    return {
      data: response.data,
    };
  },
});
