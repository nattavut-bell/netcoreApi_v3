using System;
using System.Collections.Generic;

namespace NetCoreAPI_v3.DTOs
{
    public class GetProductGroupDto
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public UserDto CreatedByUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public UserDto UpdatedByUser { get; set; }

        public DateTime UpdatedDate { get; set; }

        public List<GetProductDto> Product { get; set; }

    }
}