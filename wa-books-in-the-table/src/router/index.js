import { createRouter, createWebHashHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "home",
    component: () => import("@/views/HomeView.vue"),
  },
  {
    path: "/autores",
    name: "autores",
    component: () => import("@/views/AuthorView.vue"),
  },
  {
    path: "/autor/:id",
    name: "autor",
    component: () => import("@/views/AuthorDetailsView.vue"),
  },
  {
    path: "/editoras",
    name: "editoras",
    component: () => import("@/views/PublisherView.vue"),
  },
  {
    path: "/livros",
    name: "livros",
    component: () => import("@/views/BookView.vue"),
  },
];

const router = createRouter({
  history: createWebHashHistory(process.env.BASE_URL),
  routes,
});

export default router;
