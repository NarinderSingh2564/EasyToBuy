﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.CommonModels
{
    public class UserDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Redirect { get; set; }
    }
}