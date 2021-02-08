using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI_v3.DTOs
{
    public class EditProductDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        [Required]
        public int ProductGroupId { get; set; }
    }
}