<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>
  <h3 class="p-4">Your Favorite Recipes:</h3>
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
      v-for="f in myFavorites"
      :key="f.id"
    >
      <div class="d-flex flex-column align-items-center">
        <h4 class="text-center">{{ f.title }}</h4>
        <img class="recipeimg img-fluid" v-if="f.image" :src="f.image" alt="" />
        <img
          v-else
          class="recipeimg img-fluid rounded"
          src="https://www.weightwatchers.ca/images/4105/dynamic/foodandrecipes/2013/06/us_img_recipe_default_800x800.jpg"
          alt=""
        />

        <h6 class="text-center p-2 mt-1 pb-0 mb-2">{{ f.subtitle }}</h6>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { accountService } from "../services/AccountService"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
export default {
  name: 'Account',

  setup() {
    onMounted(async () => {
      try {
        accountService.getMyFavorites()
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    })
    return {
      account: computed(() => AppState.account),
      myFavorites: computed(() => AppState.myAccountFavorites)
    }
  }
}
</script>

<style scoped>
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
</style>
