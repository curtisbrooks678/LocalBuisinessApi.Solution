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
  public class ShopsController : ControllerBase
  {
    private readonly LocalBuisinessApiContext _db;

    public ShopsController(LocalBuisinessApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Shop>> Get([FromQuery]string name, [FromQuery]string address, [FromQuery]string specialty, [FromQuery]int rating)
    {

    var query = _db.Shops.AsQueryable();

    if (name != null)
    {
      query = query.Where(entry => entry.Name == name);
    }

    if (address != null)
    {
    query = query.Where(entry => entry.Address == address);
    }

    if (specialty != null)
    {
    query = query.Where(entry => entry.Specialty == specialty);
    }

    if (rating != 0)
    {
    query = query.Where(entry => entry.Rating == rating);
    }

    return query.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Shop>> Post([FromBody]Shop shop)
    {
      _db.Shops.Add(shop);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = shop.ShopId }, shop);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Shop>> GetShop(int id)
    {
        var shop = await _db.Shops.FindAsync(id);

        if (shop == null)
        {
            return NotFound();
        }

        return shop;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody]Shop shop)
    {
      if (id != shop.ShopId)
      {
        return BadRequest();
      }

      _db.Entry(shop).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ShopExists(id))
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
    private bool ShopExists(int id)
    {
      return _db.Shops.Any(e => e.ShopId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShop(int id)
    {
      var shop = await _db.Shops.FindAsync(id);
      if (shop == null)
      {
        return NotFound();
      }

      _db.Shops.Remove(shop);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}