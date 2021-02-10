using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI_v3.DTOs
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [Required]
        public int ProductGroupId { get; set; }
    }
}