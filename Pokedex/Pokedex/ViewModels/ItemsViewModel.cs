﻿using System;
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

namespace Pokedex.ViewModels
{
    
    public class ItemsViewModel : BaseViewModel
    {
		public ObservableRangeCollection<Item> Items { get; set; }
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

        public ItemsViewModel()
		{
			Title = "Browse";
			Items = new ObservableRangeCollection<Item>();
            SearchCommand = new Command(async () => await ExecuteSearchCommand());
            getPokemonSource();
		}

        private async void getPokemonSource()
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