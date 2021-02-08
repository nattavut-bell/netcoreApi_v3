using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreAPI_v3.Models
{
    [Table("ProductGroup")]
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

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

        public List<Product> Product { get; set; }

        public User CreatedByUser { get; set; }

        public User UpdatedByUser { get; set; }
    }
}