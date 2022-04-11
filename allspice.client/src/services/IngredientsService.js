import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { api } from "./AxiosService"
import { AppState } from "../AppState"



class IngredientsService {


  async getAll(id) {
    try {
      const res = await api.get('/api/recipes/' + id + '/ingredients')
      logger.log('getting ingredients', res.data)
      AppState.ingredients = res.data
    } catch (error) {
      logger.error(error)
      Pop.toast(error.message, 'error')
    }

  }
}
export const ingredientsService = new IngredientsService()