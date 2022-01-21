using System.ComponentModel.DataAnnotations;

namespace LocalBuisinessApi.Models
{
  public class Shop
  {
    public int ShopId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    [StringLength(200)]
    public string Address { get; set; }
    [Required]
    [StringLength(100)]
    public string Specialty { get; set; }
    [Required]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int Rating { get; set; }
  }
}