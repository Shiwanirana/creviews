using System.Collections.Generic;
using System.Data;
using creviews.Models;
using Dapper;

namespace creviews.Repositories
{
  public class RestaurantsRepository
  {
    private readonly IDbConnection _db;
    public RestaurantsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Restaurant> GetAll()
    {
      string sql = "SELECT * FROM restaurants";
      return _db.Query<Restaurant>(sql);
    }
    internal Restaurant GetById(int id)
    {
      string sql = "SELECT *FROM restaurants WHERE id= @id";
      return _db.QueryFirstOrDefault<Restaurant>(sql, new {id});
    }
    internal Restaurant Create(Restaurant newRestaurant)
    {
      string sql = @"
      INSERT INTO restaurants
      (Name, Location, Owner ) 
      VALUES
      (@Name,@Location, @Owner);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newRestaurant);
      newRestaurant.Id =id;
      return newRestaurant;
    }
    internal Restaurant Edit(Restaurant editRestaurant)
    {
      string sql = @"
      UPDATE restaurants
      SET
       Name = @Name,
       Location = @Location,
       Owner = @Owner,
       WHERE id = @Id";
       _db.Execute(sql,editRestaurant);
       return editRestaurant;
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM restaurants WHERE id = @id LIMIT 1";
      _db.Execute(sql, new{id});
    }
  }
}