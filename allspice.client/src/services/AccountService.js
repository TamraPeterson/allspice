import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getMyFavorites() {
    try {
      const res = await api.get('/account/favorites')
      logger.log('account favorites', res.data)
      AppState.myAccountFavorites = res.data
    } catch (error) {
      logger.error(error)
    }
  }
}

export const accountService = new AccountService()
