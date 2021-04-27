using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoWatchDog.Model
{
    class Crypto
    {
        public string asset_id { get; set; }
        public string name { get; set; }
        public float price_usd { get; set; }
        public string id_icon { get; set; }
        public string ico_url { get; set; }

    }
}
