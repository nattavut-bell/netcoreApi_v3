using System;
using System.Collections.Generic;

namespace NetCoreAPI_v3.DTOs
{
    public class GetProductDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public bool IsActive { get; set; }
        public UserDto CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public UserDto UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int ProductGroupId { get; set; }
    }
}