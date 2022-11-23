using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using RestSharp;
using CryptoApp.Model;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace CryptoApp
{
    public partial class MainPage : ContentPage
    {
        // Declaring CoinAPI key variable
        public string coinKey = "684B0C08-1464-4841-BB80-E2FEA9F9F5B6";

        // Declaring Crypto Coin icon variable
        public string iconImage = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";

        // Referencing Crypto list
        public List<Crypto> coins;
        public MainPage()
        {
            InitializeComponent();
            // Get crypto coins on app start
            cryptoListView.ItemsSource = GetData();
        }

        // Refresh crypto coins on button click
        private void RefreshButtonClicked(object sender, EventArgs e)
        {
            cryptoListView.ItemsSource = GetData();
        }

        // Function to retrive data from API database
        private List<Crypto> GetData()
        {
            // New RESTSharp request with parameter to filter by asset
            var client = new RestClient("http://rest.coinapi.io/v1/assets?filter_asset_id={;UIP;DOGE;TNB;PLN;BTCA;NEU;GTO;INK;TSL;WABI;}");
            // Get method request
            var request = new RestRequest(Method.GET);
            // Header to authenticate request using CoinAPI Key
            request.AddHeader("X-CoinAPI-Key", coinKey);
            // Execute request
            var response = client.Execute(request);
            // Deserialize Json data from API into C# List
            coins = JsonConvert.DeserializeObject<List<Crypto>>(response.Content);

            //Foreach statement to get icon url from API based on icon id
            foreach (var c in coins)
            {
                c.Icon_url = iconImage + c.Id_icon.Replace("-", "") + ".png";
            }

            return coins;
        }
    }
}