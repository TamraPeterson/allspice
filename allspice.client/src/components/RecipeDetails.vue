<template>
  <h5>Ingredients:</h5>
  <ul>
    <li v-for="i in ingredients" :key="i.id">
      {{ i.quantity }} of {{ i.name }}
    </li>
  </ul>
  <h5>Steps:</h5>
  <ol>
    <li v-for="s in steps" :key="s.id">{{ s.body }}</li>
  </ol>

  <!-- TODO v-if on button...if account like, show colored heart button with @click delete like, ELSE show white heart button with @click create like -->
  <div class="d-flex flex-row justify-content-between">
    <button
      class="btn btn-success m-2"
      @click="createFavorite(activeRecipe.id)"
    >
      <h3><i class="mdi mdi-heart text-white"></i></h3>
    </button>
    <!-- <button class="btn btn-success m-2">
    <h3><i class="mdi mdi-heart text-dark"></i></h3>
  </button> -->
    <button class="btn btn-success m-2" @click="openModal">
      <h3><i class="mdi mdi-pencil text-white"></i></h3>
    </button>
    <button class="btn btn-success m-2" @click="remove(activeRecipe.id)">
      <h3><i class="mdi mdi-delete text-white"></i></h3>
    </button>
  </div>
  <Modal>
    <template #modal-title>Edit {{ activeRecipe.title }}</template>
    <template #modal-body><RecipeForm :recipeData="activeRecipe" /></template>
  </Modal>
</template>


<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
import { onMounted } from "@vue/runtime-core"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { ingredientsService } from "../services/IngredientsService"
import { favoritesService } from "../services/FavoritesService"

import { Modal } from "bootstrap"
import { recipesService } from "../services/RecipesService"
export default {
  props: {
    activeRecipe: {
      type: Object,
      required: true,
    }
  },
  setup(props) {
    onMounted(async () => {

      // try {
      //   await ingredientsService.getAll()
      //   // await stepsService.getAll(id)
      // } catch (error) {
      //   logger.error(error)
      //   Pop.toast(error.message, 'error')
      // }
    })
    return {
      activeRecipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.ingredients),
      steps: computed(() => AppState.steps),
      favorites: computed(() => AppState.favorites),
      openModal() {
        Modal.getOrCreateInstance(document.getElementById("form-modal")).show();
      },
      remove(id) {
        try {
          recipesService.remove(id)
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }

      },
      createFavorite(recipeId) {
        try {
          favoritesService.createFavorite(recipeId)
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
</style>