using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using allspice.Models;
using allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly RecipesService _rs;

    public AccountController(AccountService accountService, RecipesService rs)
    {
      _accountService = accountService;
      _rs = rs;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // Get Account Favorites
    [HttpGet("favorites")]
    [Authorize]
    public async Task<ActionResult<List<FavoriteViewModel>>> GetAccountFavorites()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<FavoriteViewModel> favorites = _rs.GetFavoritesByAccount(userInfo.Id);
        return Ok(favorites);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }


}