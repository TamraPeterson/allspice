<template>
  <div class="container-fluid image bg-light">
    <div class="row justify-content-between p-3">
      <div class="col-md-6 mt-3 text-dark d-flex flex-row">
        <button
          v-if="account.id"
          class="button btn ms-2 mt-0 btn-success"
          @click="openModal()"
        >
          <i class="mdi mdi-plus"></i>
        </button>
        <h6 class="selectable ms-md-5" @click="getAll()">All</h6>
        <h6
          class="selectable ms-md-5 ms-3"
          @click="getFilteredRecipes('Appetizers')"
        >
          Appetizers
        </h6>
        <h6
          class="selectable ms-md-5 ms-3"
          @click="getFilteredRecipes('Dinner')"
        >
          Dinners
        </h6>
        <h6
          class="selectable ms-md-5 ms-3"
          @click="getFilteredRecipes('Desserts')"
        >
          Desserts
        </h6>
        <h6 class="selectable ms-md-5 ms-3" @click="getFilteredRecipes('Soup')">
          Soups
        </h6>
      </div>
      <div class="col-md-6"><SearchBar /></div>
    </div>
    <div class="row justify-content-center">
      <div
        class="
          col-md-2
          shadow
          rounded
          bg-success
          text-dark
          mt-3
          m-3
          card
          p-3
          selectable
        "
        @click="getById(r.id)"
        v-for="r in recipes"
        :key="r.id"
      >
        <RecipeCard :recipe="r" />
      </div>
    </div>
  </div>
  <Modal id="recipesModal">
    <template #modal-title>
      <h3>{{ activeRecipe.title }}</h3>
      <h5>{{ activeRecipe.subtitle }}</h5></template
    >
    <template #modal-body><RecipeDetails :key="activeRecipe.id" /></template>
  </Modal>
  <Modal id="form-modal">
    <template #modal-title>Add a recipe:</template>
    <template #modal-body><RecipeForm :recipeData="recipe" /></template>
  </Modal>
</template>

<script>
import { computed, watchEffect } from "@vue/runtime-core"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { recipesService } from "../services/RecipesService"
import { AppState } from "../AppState"
import { Modal } from "bootstrap"
import { ingredientsService } from "../services/IngredientsService"
import { stepsService } from "../services/StepsService"
export default {
  name: 'Home',
  data() {
    return {
      category: '',
    }
  },
  setup() {
    watchEffect(async () => {
      try {
        await recipesService.getAll()
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    })
    return {
      recipes: computed(() => AppState.recipes),
      activeRecipe: computed(() => AppState.activeRecipe),
      account: computed(() => AppState.account),
      favorites: computed(() => AppState.favorites),
      favorited: computed(() => AppState.favorites.find(f => f.accountId == AppState.account.id)),
      async getById(id) {
        try {
          await recipesService.getById(id)
          await ingredientsService.getAll(id)
          await stepsService.getAll(id)
          Modal.getOrCreateInstance(document.getElementById("recipesModal")).show();
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      getFilteredRecipes(category) {
        logger.log('filtering recipes', category)
        recipesService.getFilteredRecipes(category)
      },
      getAll() {
        recipesService.getAll()
      },
      openModal() {
        Modal.getOrCreateInstance(document.getElementById("form-modal")).show();
      }
    }
  }
}
</script>

<style scoped lang="scss">
.card {
  opacity: 0.9;
  transition: 0.5s;
}
.card:hover {
  transform: scale(1.05);
  transition: 0.5s;
}
.button {
  border-radius: 50%;
  transform: translateY(-20%);
}
</style>
