﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.CommonModel
{
    public class ApiResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
    }
}
