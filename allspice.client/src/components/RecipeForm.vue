<template>
  <div class="bg-white">
    <form>
      <div class="form-group">
        <label for="title" class="form-label mt-2">Recipe Title:</label>
        <input
          v-model="editable.title"
          type="title"
          class="form-control"
          id="recipe-title"
        />
      </div>
      <div class="form-group">
        <label for="subtitle" class="form-label mt-2">Subtitle:</label>
        <input
          v-model="editable.subtitle"
          type="name"
          class="form-control"
          id="recipe-subtitle"
        />
      </div>
      <div class="form-group">
        <label for="type" class="form-label mt-2">Category:</label><br />
        <select
          name="recipe-category"
          v-model="editable.category"
          class="custom-select rounded"
          id="recipe-category"
        >
          <option value="Appetizers">Appetizer</option>
          <option value="Dinners">Dinner</option>
          <option value="Desserts">Dessert</option>
          <option value="Soup">Soup</option>
        </select>
      </div>

      <div class="form-group">
        <label for="title" class="form-label mt-2">Image:</label>
        <input
          v-model="editable.image"
          type="url"
          class="form-control"
          id="recipe-image"
        />
      </div>

      <button
        v-if="!recipeData.id"
        @click="createRecipe"
        type="submit"
        class="btn btn-success mt-3"
      >
        Create
      </button>
      <button
        v-else
        @click="editRecipe"
        type="submit"
        class="btn btn-success mt-3"
      >
        Save Changes
      </button>
    </form>
  </div>
</template>


<script>
import { reactive, ref } from "@vue/reactivity";
import { recipesService } from "../services/RecipesService"
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";
import { Modal } from "bootstrap";
import { useRouter } from "vue-router";
import { watchEffect } from "@vue/runtime-core";
export default {
  props: {
    recipeData: {
      type: Object,
      required: false,
      default: {}
    }
  },
  setup(props) {
    const editable = ref({})
    const router = useRouter()
    watchEffect(() => {
      editable.value = props.recipeData
    })
    return {
      editable,
      async createRecipe() {
        try {
          let newRecipe = await recipesService.create(editable.value);
          editable.value = {};
          Modal.getOrCreateInstance(
            document.getElementById("form-modal")
          ).hide();
          logger.log('new recipe', newRecipe)
        } catch (error) {
          logger.error(error);
          Pop.toast(error.message, "error");
        }
      },
      async editRecipe() {
        try {

          await recipesService.update(editable.value);
          // editable.value = {}
          Modal.getOrCreateInstance(document.getElementById("form-modal")).hide();
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      }
    }
  },
}
</script>


<style lang="scss" scoped>
.custom-select {
  width: 465px;
  height: 38px;
}
@media only screen and (max-width: 600px) {
  #event-type {
    width: 325px;
  }
}
</style>