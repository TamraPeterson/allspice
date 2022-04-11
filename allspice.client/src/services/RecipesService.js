import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { api } from "./AxiosService"

class RecipesService {


  async getAll() {
    try {
      const res = await api.get('/api/recipes')
      logger.log('getting recipes', res.data)
      AppState.recipes = res.data
    } catch (error) {
      logger.error(error)
      Pop.toast(error.message, 'error')
    }
  }

  async getById(id) {
    try {
      const res = await api.get('api/recipes/' + id)
      logger.log('get recipe by id', res.data)
      AppState.activeRecipe = res.data
    } catch (error) {
      logger.error(error)
      Pop.toast(error.message, 'error')
    }
  }

  async getFilteredRecipes(category) {
    try {
      await this.getAll()
      const filteredRecipes = AppState.recipes.filter(r => r.category == category)
      logger.log('filtered recipes', filteredRecipes)
      AppState.recipes = filteredRecipes
    } catch (error) {
      logger.error(error)
      Pop.toast(error.message, 'error')
    }
  }

  async searchRecipes(query) {
    AppState.recipes = []
    const res = await api.get('api/recipes')
    AppState.recipes = res.data
    query = query.toLowerCase()
    const reg = new RegExp(query, 'ig')
    AppState.recipes = AppState.recipes.filter(r => reg.exec(r.title))
    logger.log('new array who dis?', AppState.recipes)
  }

  async create(recipeData) {
    recipeData.creatorId = AppState.account.id
    const res = await api.post('api/recipes', recipeData)
    logger.log('create recipe', res.data)
    AppState.recipes.push(res.data)
    this.getAll()
    return res.data

  }

  async update(recipeData) {
    const res = await api.put('api/recipes/' + recipeData.id, recipeData)
    logger.log('update recipe', res.data)
    AppState.activeRecipe = res.data
    this.getAll()
  }

  async remove(id) {
    const res = await api.delete('api/recipes/' + id)
    logger.log('delete recipe', res.data)
  }
}

export const recipesService = new RecipesService()