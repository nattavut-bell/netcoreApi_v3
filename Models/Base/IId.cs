﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPI_v3.Models
{
    public interface IId
    {
        public Guid Id { get; set; }
    }
}