using System.ComponentModel.DataAnnotations;

namespace LocalBuisinessApi.Models
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    [StringLength(200)]
    public string Address { get; set; }
    [Required]
    [StringLength(100)]
    public string Cuisine { get; set; }
    [Required]
    [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
    public int Rating { get; set; }
  }
}