using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalBuisinessApi.Models;
using System.Linq;
using System;

namespace LocalBuisinessApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RestaurantsController : ControllerBase
  {
    private readonly LocalBuisinessApiContext _db;

    public RestaurantsController(LocalBuisinessApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Restaurant>> Get([FromQuery]string name, [FromQuery]string address, [FromQuery]string cuisine, [FromQuery]int rating)
    {

    var query = _db.Restaurants.AsQueryable();

    if (name != null)
    {
      query = query.Where(entry => entry.Name == name);
    }

    if (address != null)
    {
    query = query.Where(entry => entry.Address == address);
    }

    if (cuisine != null)
    {
    query = query.Where(entry => entry.Cuisine == cuisine);
    }

    if (rating != 0)
    {
    query = query.Where(entry => entry.Rating == rating);
    }

    return query.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Restaurant>> Post([FromBody]Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = restaurant.RestaurantId }, restaurant);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurant([FromQuery]int id)
    {
        var restaurant = await _db.Restaurants.FindAsync(id);

        if (restaurant == null)
        {
            return NotFound();
        }

        return restaurant;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromQuery]int id, [FromBody]Restaurant restaurant)
    {
      if (id != restaurant.RestaurantId)
      {
        return BadRequest();
      }

      _db.Entry(restaurant).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RestaurantExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    private bool RestaurantExists(int id)
    {
      return _db.Restaurants.Any(e => e.RestaurantId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant([FromQuery]int id)
    {
      var restaurant = await _db.Restaurants.FindAsync(id);
      if (restaurant == null)
      {
        return NotFound();
      }

      _db.Restaurants.Remove(restaurant);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}