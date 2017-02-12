using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDudekGueguen.Models
{
    class Table
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("max_seat")]
        public int Max_Seat { get; set; }

        [JsonProperty("seats_available")]
        public int Seats_Available { get; set; }

        [JsonProperty("min_bet")]
        public Double Min_Bet { get; set; }

        [JsonProperty("last_activity")]
        public DateTime Last_Activity { get; set; }

        [JsonProperty("is_closed")]
        public Double Is_Closed { get; set; }

        [JsonProperty("created_at")]
        public DateTime Created_At { get; set; }

        [JsonProperty("updated_at")]
        public DateTime Updated_At { get; set; }
    }
}
