using System;
using System.Collections.Generic;
using creviews.Models;
using creviews.Services;
using Microsoft.AspNetCore.Mvc;
namespace creviews.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RestaurantsController : ControllerBase
  {
    private readonly RestaurantsService _rs;
    // private readonly IngredientsService _ingredientsService;
    public RestaurantsController(RestaurantsService rs)
    {
      _rs = rs;
      // _ingredientsService = gs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Restaurant>> Get()
    {
      try{
      return Ok(_rs.GetAll());
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Restaurant> GetAction(int id)
    {
      try{
        return Ok(_rs.GetById(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // [HttpGet("{id}/Ingredients")]
    // public ActionResult<IEnumerable<Ingredient>> GetIngredients(int id)
    // {
    //   try{
    //     IEnumerable<Ingredient> data = _ingredientsService.GetByRestaurantId(id);
    //     return Ok(data);
    //   }
    //   catch(Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
    [HttpPost]
    public ActionResult<Restaurant> Create([FromBody] Restaurant newRestaurant)
    {
      try{
      return Ok(_rs.Create(newRestaurant));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Restaurant> Edit(int id,[FromBody] Restaurant editRestaurant)
    {
      try{
        editRestaurant.Id = id;
        return Ok(_rs.Edit(editRestaurant));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Restaurant> Delete(int id)
    {
      try{
        return Ok(_rs.Delete(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}