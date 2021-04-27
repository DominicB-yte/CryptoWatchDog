using CryptoWatchDog.Model;
using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptoWatchDog
{
    public partial class MainPage : ContentPage
    {
        private string apiKey = "D3148A98-F739-47DB-9905-BD8FDB88A228";
        private string icoUrlBase = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";
        private List<Crypto> cryptos;
        private RestClient client;

        public MainPage()
        {
            InitializeComponent();

            cryptoView.ItemsSource = GetCryptos();
        }

        private void btnRefresh_Clicked(object sender, EventArgs e)
        {
            cryptoView.ItemsSource = GetCryptos();
        }
        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            cryptoView.ItemsSource = AddCryptos();
        }

        private void btnRemove_Clicked(object sender, EventArgs e)
        {
            cryptoView.ItemsSource = RemoveCryptos();
        }

        private List<Crypto> GetCryptos()
        {
            client = new RestClient("https://rest.coinapi.io/v1/assets?filter_asset_id=BTC;LTC;ETH;NAV;USDT");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinPAI-Key", apiKey);
            IRestResponse response = client.Execute(request);
            cryptos = JsonConvert.DeserializeObject<List<Crypto>>(response.Content);

            foreach (var c in cryptos)
            {
                if (!String.IsNullOrEmpty(c.id_icon))
                    c.ico_url = icoUrlBase + c.id_icon.Replace("-", "") + ".png";
                else
                    c.id_icon = "https://cdn.iconscout.com/icon/free/png-512/usd-1-459191.png";
            }

            return cryptos;
        }

        private List<Crypto> AddCryptos()
        {
            if (Entry != null)
            {
                string EntryText = ";" + Entry.Text;
                client = new RestClient("https://rest.coinapi.io/v1/assets?filter_asset_id=BTC;LTC;ETH;NAV;USDT" + EntryText);
            }
            else { client = new RestClient("https://rest.coinapi.io/v1/assets?filter_asset_id=BTC;LTC;ETH;NAV;USDT"); }

            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinPAI-Key", apiKey);
            IRestResponse response = client.Execute(request);
            cryptos = JsonConvert.DeserializeObject<List<Crypto>>(response.Content);

            foreach (var c in cryptos)
            {
                if (!String.IsNullOrEmpty(c.id_icon))
                    c.ico_url = icoUrlBase + c.id_icon.Replace("-", "") + ".png";
                else
                    c.id_icon = "https://cdn.iconscout.com/icon/free/png-512/usd-1-459191.png";
            }

            return cryptos;
        }

        private List<Crypto> RemoveCryptos()
        {
            if (Entry != null)
            {
                string EntryText = ";" + Entry.Text;
                string ClientString = "https://rest.coinapi.io/v1/assets?filter_asset_id=BTC;LTC;ETH;NAV;USDT";
                if (ClientString.Contains(EntryText))
                {
                    ClientString.Replace(EntryText, "");
                }
                client = new RestClient(ClientString);
            }
            else { client = new RestClient("https://rest.coinapi.io/v1/assets?filter_asset_id=BTC;LTC;ETH;NAV;USDT"); }

            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinPAI-Key", apiKey);
            IRestResponse response = client.Execute(request);
            cryptos = JsonConvert.DeserializeObject<List<Crypto>>(response.Content);

            foreach (var c in cryptos)
            {
                if (!String.IsNullOrEmpty(c.id_icon))
                    c.ico_url = icoUrlBase + c.id_icon.Replace("-", "") + ".png";
                else
                    c.id_icon = "https://cdn.iconscout.com/icon/free/png-512/usd-1-459191.png";
            }

            return cryptos;
        }
    }
}
