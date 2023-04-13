export default (httpClient) => ({
  getPublishers: async (url) => {
    const response = await httpClient.get(url);
    return {
      data: response.data,
    };
  },
});
