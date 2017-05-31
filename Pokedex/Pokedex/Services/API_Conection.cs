

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
        string evo1 = string.Empty, evo2 = string.Empty, evo3 = string.Empty;
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
            List<string> weaknessesList;
            foreach (Pokemon data in root.pokemon)
            {
                weaknessesList = new List<string>();
                getEvolutions(data);
                foreach (string item in data.weaknesses)
                {
                    weaknessesList.Add(item);
                }
                if(weaknessesList.Count < 4)
                {
                    for(int i = weaknessesList.Count; i < 5; i++)
                    {
                        weaknessesList.Add(string.Empty);
                    }
                }
                items.Add(new Item { Id = Guid.NewGuid().ToString(), Name = data.name, Height = data.height, Weight = data.weight, Weaknesses = weaknessesList, Type1 = data.type[0], Type2 =  data.type.Length > 1 ? data.type[1] : "-----", Num = int.Parse(data.num), Source = data.img });
            }
            return items;
        }
        private void getEvolutions(Pokemon pkm)
        {

        }
    }
}
