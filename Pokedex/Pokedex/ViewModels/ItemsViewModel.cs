/*
**********************
* Author: luisduenas * 
* Date: May 31 2017  *
**********************
 */
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Pokedex.Helpers;
using Pokedex.Models;
using Pokedex.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using PropertyChanged;
using System.ComponentModel;
using Pokedex.Services;
using static Pokedex.Models.RootItem;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Pokedex.ViewModels
{

    public class ItemsViewModel : BaseViewModel
    {
        //Variables Globales
        public ObservableRangeCollection<Item> Items { get; set; }
        ObservableRangeCollection<Item> pokemonSource = new ObservableRangeCollection<Item>();
        public ObservableRangeCollection<string> PokemonTypes { get; set; }
        private int _message { get; set; }
        public int Message
        {

            get { return _message; }

            set
            {
                _message = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Message"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        int selectedOrder;
        public int SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                if (selectedOrder != value)
                {
                    selectedOrder = value;
                    orderList();
                }
            }
        }
        int selectedType1;
        public int SelectedType1
        {
            get
            {
                return selectedType1;
            }
            set
            {
                if (selectedType1 != value)
                {
                    selectedType1 = value;
                    filtraPorTipo1();
                }
            }
        }
        int selectedType2;
        public int SelectedType2
        {
            get
            {
                return selectedType2;
            }
            set
            {
                if (selectedType2 != value)
                {
                    selectedType2 = value;
                    filtraPorTipo2();
                }
            }
        }
        string searchText;
        public string SearchText
        {
            get
            { return searchText; }
            set
            {
                if (value != searchText)
                {
                    searchText = value;
                }
            }
        }
        public Command SearchCommand { get; } 
        //Constructor
        public ItemsViewModel()
        {
            Title = "Pokedex";
            Items = new ObservableRangeCollection<Item>();
            pokemonSource = new ObservableRangeCollection<Item>();
            PokemonTypes = new ObservableRangeCollection<string>();
            SearchCommand = new Command(async () => await ExecuteSearchCommand());
            getPokemonSource();
        }
        //Metodos de carga
        private async void getPokemonSource()
        {
            try
            {
                Items.Clear();
                API_Conection conexion = new API_Conection();
                var items = await conexion.getApiResults(SearchText);
                Items.ReplaceRange(items);
                pokemonSource.ReplaceRange(items);
                getPokemonTypes();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
        }
        private void getPokemonTypes()
        {
            bool existType1 = false;
            bool existType2 = false;
            PokemonTypes.Add("All");
            foreach (Item pkms in Items)
            {
                foreach (string item in PokemonTypes)
                {
                    if (pkms.Type1 != "-----")
                    {
                        if (item == pkms.Type1)
                        {
                            existType1 = true;
                        }
                        else
                        {
                            existType1 = false;
                        }
                    }
                    else
                    {
                        existType1 = true;
                    }
                    if (pkms.Type2 != "-----")
                    {

                        if (item == pkms.Type2)
                        {
                            existType2 = true;
                        }
                        else
                        {
                            existType2 = false;
                        }
                    }
                    else
                    {
                        existType2 = true;
                    }
                }
                if (!existType1)
                {
                    PokemonTypes.Add(pkms.Type1);
                }
                if (!existType2)
                {
                    PokemonTypes.Add(pkms.Type2);
                }
            }
            var lista = PokemonTypes.Distinct().ToList().OrderBy(o => o).ToList();
            PokemonTypes.ReplaceRange(lista);
        }
        //Eventos
        private void SelectedPokemon_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //Administracion
        private void filtraPorTipo1()
        {
            string tipo1 = PokemonTypes[SelectedType1];
            string tipo2 = PokemonTypes[SelectedType2];

            if (SelectedType1 > 0 && SelectedType2 < 1)
            {
                var lista = pokemonSource.Where(w => w.Type1.Equals(tipo1) || w.Type2.Equals(tipo1)).ToList();
                Items.ReplaceRange(lista);
            }
            else if (SelectedType1 > 0 && SelectedType2 > 0)
            {
                string tipo = PokemonTypes[SelectedType2];
                var lista = pokemonSource.Where(w => (w.Type1.Equals(tipo1) && w.Type2.Equals(tipo2)) || (w.Type1.Equals(tipo2) && w.Type2.Equals(tipo1))).ToList();
                Items.ReplaceRange(lista);
            }
            else if (selectedType1 < 1 && SelectedType2 > 0)
            {
                filtraPorTipo2();
            }
            else if (SelectedType1 < 1 && SelectedType2 < 1)
            {
                Items.ReplaceRange(pokemonSource);
            }
            Message = Items.Count();
        }
        private void filtraPorTipo2()
        {
            string tipo1 = PokemonTypes[SelectedType1];
            string tipo2 = PokemonTypes[SelectedType2];

            if (SelectedType2 > 0 && SelectedType1 > 0)
            {
                var lista = pokemonSource.Where(w => (w.Type1.Equals(tipo1) && w.Type2.Equals(tipo2)) || (w.Type1.Equals(tipo2) && w.Type2.Equals(tipo1))).ToList();
                Items.ReplaceRange(lista);
            }
            else if (SelectedType2 > 0 && SelectedType1 < 1)
            {
                string tipo = PokemonTypes[SelectedType2];
                var lista = pokemonSource.Where(w => w.Type1.Equals(tipo) || w.Type2.Equals(tipo)).ToList();
                Items.ReplaceRange(lista);
            }
            else if (SelectedType2 < 1 && SelectedType1 < 1)
            {
                Items.ReplaceRange(pokemonSource);
            }
            else
            {
                filtraPorTipo1();
            }
            Message = Items.Count();
        }
        private void orderList()
        {
            if (selectedOrder == 0)
            {
                var lista = Items.OrderBy(o => o.Num).ToList();
                Items.ReplaceRange(lista);
            }
            else
            {
                var lista = Items.OrderBy(o => o.Name).ToList();
                Items.ReplaceRange(lista);
            }
        }
        async Task ExecuteSearchCommand()
        {
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                try
                {
                    Items.Clear();
                    API_Conection conexion = new API_Conection();
                    var items = await conexion.getApiResults(SearchText);
                    Items.ReplaceRange(items);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    MessagingCenter.Send(new MessagingCenterAlert
                    {
                        Title = "Error",
                        Message = "Unable to load items.",
                        Cancel = "OK"
                    }, "message");
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
    }
}