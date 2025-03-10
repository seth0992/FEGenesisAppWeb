﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEGenesisAppWeb.Models.Models.Auth
{
    public class LoginResponseModel
    {
        [JsonProperty("token")]  // Asegura el mapeo correcto con el JSON
        public string Token { get; set; } = string.Empty;

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; } = string.Empty;

        [JsonProperty("tokenExpired")]
        public long TokenExpired { get; set; }

        [JsonProperty("user")]
        public UserDto User { get; set; } = null!;
    }
}
