﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Models.Auth
{
    public class RevokeTokenRequest
    {
        public string Token { get; set; } = string.Empty;
    }
}
