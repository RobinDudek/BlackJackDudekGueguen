using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BlackJackDudekGueguen.Model
{
    class User
    {
        public Hand Hands { get; set; }

        [JsonProperty("user_id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("created_at")]
        public DateTime Created_At { get; set; }

        [JsonProperty("updated_at")]
        public DateTime Updated_At { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("stack")]
        public int Stack { get; set; }

        [JsonProperty("is_connected")]
        public bool Is_Connected { get; set; }

        [JsonProperty("last_refill")]
        public DateTime Last_Refill { get; set; }

    }
}
