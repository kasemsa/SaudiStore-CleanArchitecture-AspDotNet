using System.ComponentModel.DataAnnotations;

namespace SaudiStore.App.ViewModels
{
    public class ProductDetailViewModel
    {
        public Guid ProductId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="The name of the Product should be 50 characters or less")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage ="Price should be a positive value")]
        public int Price { get; set; }

        [StringLength(50, ErrorMessage = "The name of the Company should be 50 characters or less")]
        public string? CompanyName { get; set; }

       
        
        [StringLength(500, ErrorMessage = "The description can't be longer than 500 characters")] 
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public CategoryViewModel Category { get; set; } = default!;
    }
}
