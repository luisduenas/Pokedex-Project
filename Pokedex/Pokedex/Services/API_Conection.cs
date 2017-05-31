

using Pokedex.Models;
using Pokedex.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static Pokedex.Models.RootItem;

namespace Pokedex.Services
{
    public class API_Conection : BaseViewModel
    {
        public async Task<ObservableCollection<Item>> getApiResults(string searchText)
        {
            var uri = new Uri("https://api.myjson.com/bins/1c5nwx");
            Rootobject root;
            string results = string.Empty;
            ObservableCollection<Item> items = new ObservableCollection<Item>();
            HttpClient wc = new HttpClient();
            HttpResponseMessage response = await wc.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic jo = JObject.Parse(responseBody);
            root = jo.ToObject<Rootobject>();

            foreach (var data in root.pokemon)
            {
                items.Add(new Item { Id = Guid.NewGuid().ToString(), Name = data.name, Height = data.height, Weight = data.weight, Weaknesses = data.weaknesses, Type1 = data.type[0], Type2 =  data.type.Length > 1 ? data.type[1] : "-----", Num = int.Parse(data.num), Source = data.img });
            }
            return items;
        }
    }
}
