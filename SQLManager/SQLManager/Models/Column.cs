﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLManager.Models
{
    internal class Column
    {
        public string? DataType { get; set; }
        public string? Name { get; set; }
        public override string ToString() => $"{Name}({DataType})";
    }
}
