using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using creviews.Models;
using creviews.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace creviews.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly RestaurantsService _rs;
    public ProfilesController(ProfilesService ps, RestaurantsService rs)
    {
      _ps=ps;
      _rs =rs;
    }
    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfileById(string id)
    {
      try{
      return Ok(_ps.GetProfileById(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/Restaurants")]
    [Authorize]
    public ActionResult<IEnumerable<RestaurantProfileViewModel>> GetRestaurantsByProfileId(string id)
    {
      try
      {
        IEnumerable<RestaurantProfileViewModel> Restaurants = _rs.GetRestaurantsByProfileId(id);
        return Ok(Restaurants);
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}