using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetCoreAPI_v3.DTOs;

namespace NetCoreAPI_v3.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public Guid CreatedByUserId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public Guid UpdatedByUserId { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }


        [Required]
        public int ProductGroupId { get; set; }

        public ProductGroup ProductGroup { get; set; }

        public User CreatedByUser { get; set; }

        public User UpdatedByUser { get; set; }
    }
}