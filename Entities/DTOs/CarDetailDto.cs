﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto
    {
        public int CarId { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }


    }
}
