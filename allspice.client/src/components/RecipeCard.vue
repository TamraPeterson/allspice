<template>
  <div class="d-flex flex-column align-items-center">
    <p class="category p-1 bg-dark mb-3">{{ recipe.category }}</p>

    <h4 class="text-center">{{ recipe.title }}</h4>
    <img
      class="recipeimg img-fluid"
      v-if="recipe.image"
      :src="recipe.image"
      alt=""
    />
    <img
      v-else
      class="recipeimg img-fluid rounded"
      src="https://www.weightwatchers.ca/images/4105/dynamic/foodandrecipes/2013/06/us_img_recipe_default_800x800.jpg"
      alt=""
    />

    <h6 class="text-center p-2 mt-1 pb-0 mb-2">{{ recipe.subtitle }}</h6>
  </div>

  <!-- <Modal>
    <template #modal-title>{{ recipe.title }}</template>
    <template #modal-body>{{ recipe.subtitle }} Ingredients and steps</template>
  </Modal> -->
</template>


<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
import { onMounted } from "@vue/runtime-core"
import Modal from "./Modal.vue"
export default {
  components: { Modal },
  props: {
    recipe: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {
      recipes: computed(() => AppState.recipes)

    }
  }
}
</script>


<style lang="scss" scoped>
.recipeimg {
  object-fit: cover;
  height: 230px;
  width: 230px;
}
@media only screen and(max-width: 700px) {
  .recipeimg {
    object-fit: cover;
    object-position: center;
    height: 500px;
    width: 500px;
  }
}
.category {
  display: inline-block;
  margin: auto;
  border-radius: 40px;
  opacity: 50%;
  font-size: small;
}
</style>