<template></template>


<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
import { recipesService } from "../services/RecipesService"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
export default {

  setup() {

    return {
      recipes: computed(() => AppState.recipes),

    }
  }
}
</script>


<style lang="scss" scoped>
</style>