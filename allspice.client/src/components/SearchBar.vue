<template>
  <form
    class="row form-group justify-content-center pt-2 mt-2 mt-md-0"
    @submit.prevent="search"
  >
    <input
      type="text"
      v-model="searchTerm"
      class="col-8 rounded-2 bg-light darken-10 search-shadow font-search"
      placeholder="Search for a recipe..."
    />
    <button class="btn ms-1 p-1 col-2 rounded-2 bg-success search-shadow">
      Search
    </button>
  </form>

  <link rel="preconnect" href="https://fonts.googleapis.com" />
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
  <link
    href="https://fonts.googleapis.com/css2?family=Nanum+Pen+Script&display=swap"
    rel="stylesheet"
  />
</template>

<script>
import { ref } from '@vue/reactivity'
import { logger } from '../utils/Logger'
import { recipesService } from '../services/RecipesService'
import Pop from '../utils/Pop'
export default {
  setup() {
    const searchTerm = ref('')
    return {
      searchTerm,
      async search() {
        try {
          await recipesService.searchRecipes(searchTerm.value)
        } catch (error) {
          logger.log(error)
          Pop.toast(error.message, "error")
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.search-shadow {
  filter: drop-shadow(2px 2px 3px rgba(71, 63, 63, 0.6));
  transition: all 0.2s ease;
}
.search-shadow:hover {
  filter: drop-shadow(3px 3px 5px rgba(71, 63, 63, 0.6));
}
.font-search {
  color: rgb(36, 36, 37);
}
</style>