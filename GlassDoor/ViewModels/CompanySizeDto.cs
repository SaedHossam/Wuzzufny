﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CompanySizeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CompanySizeCreateDto
    {
        public string Name { get; set; }
    }
}