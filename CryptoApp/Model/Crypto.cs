using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoApp.Model
{
    //Declaring Crypto List
    public class Crypto
    {
        public string Asset_id { get; set; }

        public string Name { get; set; }

        public string Price_usd { get; set; }

        public string Id_icon { get; set; }
        public string Icon_url { get; set; }

    }
}
