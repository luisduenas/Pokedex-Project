

using Gif_Search.Models;
using Gif_Search.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static Gif_Search.Models.RootItem;

namespace Gif_Search.Services
{
    public class API_Conection : BaseViewModel
    {
        public async Task<ObservableCollection<Item>> getApiResults(string searchText)
        {
            var uri = new Uri("http://api.giphy.com/v1/gifs/search?q=" + searchText + "&api_key=dc6zaTOxFJmzC&limit=100&lang=es");
            Rootobject root;
            string results = string.Empty;
            ObservableCollection<Item> items = new ObservableCollection<Item>();
            HttpClient wc = new HttpClient();
            HttpResponseMessage response = await wc.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic jo = JObject.Parse(responseBody);
            root = jo.ToObject<Rootobject>();

            foreach (var data in root.data)
            {
                items.Add(new Item { Id = Guid.NewGuid().ToString(), Text = data.slug, Description = data.username, Source = data.images.original.url });
            }
            return items;
        }
    }
}
