﻿using Room8Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room8Project.Domain.Entities
{
    public class Passenger : Person
    {
        public string City { get; set; }
    }
}
