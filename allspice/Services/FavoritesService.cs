using System;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class FavoritesService
  {
    private readonly FavoritesRepository _fr;
    public FavoritesService(FavoritesRepository fr)
    {
      _fr = fr;
    }
    internal object Create(Favorite favoriteData)
    {
      return _fr.Create(favoriteData);
    }

    internal object Remove(int id, Account userInfo)
    {
      Favorite favorite = _fr.GetById(id);
      if (favorite.AccountId != userInfo.Id)
      {
        throw new Exception("Not your job buddy");
      }
      return _fr.Remove(id);
    }
  }
}