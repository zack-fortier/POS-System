﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P05.Web.Features.Tables
{
    public class CheckInDto
    {
        public int TableId { get; set; }
        public int CustomerId { get; set; }
        public char Status = 'w';
    }
}
