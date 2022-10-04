import { defineConfig } from "cypress";

export default defineConfig({
  env: {
    Target_url: 'http://localhost:8080/'
  },
  video: false,
  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
});
