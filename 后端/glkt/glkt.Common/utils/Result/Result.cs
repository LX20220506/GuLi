﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Common.Utils.Result
{
    public class Result
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }
    }
}
