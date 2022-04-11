import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { api } from "./AxiosService"

class StepsService {

  async getAll(id) {
    try {
      const res = await api.get('/api/recipes/' + id + '/steps')
      logger.log('getting steps', res.data)
      AppState.steps = res.data
    } catch (error) {
      logger.error(error)
      Pop.toast(error.message, 'error')
    }

  }
}

export const stepsService = new StepsService()