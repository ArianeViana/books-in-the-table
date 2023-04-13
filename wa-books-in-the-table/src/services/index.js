import axios from "axios";
import AuthorsService from "./authors";
import PublishersService from "./publisher";
import BooksService from "./book";

export const httpClient = axios.create({
  baseURL: "http://localhost:5195",
  headers: {
    "Content-Type": "application/json",
  },
});

export default {
  authors: AuthorsService(httpClient),
  publishers: PublishersService(httpClient),
  books: BooksService(httpClient),
};
