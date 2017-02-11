﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDudekGueguen.Models
{
    class Token
    {
        [JsonProperty("token_type")]
        public string token_type { get; set; }
        [JsonProperty("expires_in")]
        public int Expires_In { get; set; }
        [JsonProperty("access_token")]
        public int Access_Token { get; set; }
        [JsonProperty("refresh_token")]
        public int Refresh_Token { get; set; }
    }
}
