using System;
using System.Collections.Generic;
using creviews.Models;
using creviews.Repositories;

namespace creviews.Services
{
  public class RestaurantsService
  {
    private readonly RestaurantsRepository _repo;
    public RestaurantsService(RestaurantsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Restaurant> GetAll()
    {
      return _repo.GetAll();
    }
    internal Restaurant GetById(int id)
    {
      Restaurant data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }
    internal Restaurant Create(Restaurant newData)
    {
     return _repo.Create(newData);
    }
    internal Restaurant Edit(Restaurant editRestaurant)
    {
      Restaurant data = GetById(editRestaurant.Id);
      editRestaurant.Name=editRestaurant.Name!= null && editRestaurant.Name.Length>2 ? editRestaurant.Name:data.Name;
      editRestaurant.Location = editRestaurant.Location != null ? editRestaurant.Location : data.Location;
      editRestaurant.Owner  = editRestaurant.Owner != null ? editRestaurant.Owner : data.Owner;
      return _repo.Edit(editRestaurant);
    }
    internal string Delete(int id)
    {
      Restaurant data = GetById(id);
      _repo.Delete(id);
      return "Deleted Permanently";
    }
  }
}