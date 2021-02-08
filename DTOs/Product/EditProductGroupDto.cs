using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI_v3.DTOs
{
    public class EditProductGroupDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}