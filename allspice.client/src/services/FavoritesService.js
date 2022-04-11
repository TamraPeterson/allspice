import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FavoritesService {

  async createFavorite(recipeId) {

    const favoriteData = {
      AccountId: AppState.account.accountId,
      RecipeId: recipeId
    }
    const res = await api.post('api/favorites', favoriteData)
    logger.log('create favorite', res.data)
    AppState.favorites.push(favoriteData)
    AppState.myAccountFavorites.push(favoriteData)

  }

  async removeFavorite(id) {
    await api.delete('api/favorites/' + id)
    logger.log('removed fav', id)
  }
}

export const favoritesService = new FavoritesService()