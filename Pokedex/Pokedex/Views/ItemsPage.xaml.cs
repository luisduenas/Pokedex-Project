/*
**********************
* Author: luisduenas * 
* Date: May 31 2017  *
**********************
 */
using System;

using Pokedex.Models;
using Pokedex.ViewModels;

using Xamarin.Forms;

namespace Pokedex.Views
{
	public partial class ItemsPage : ContentPage
	{
        //Variables
		ItemsViewModel viewModel;
        //Constructor
		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ItemsViewModel();
		}
        //Eventos
		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}
		async void AboutUs_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewItemPage());
		}
        //Override
		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.SearchCommand.Execute(null);
		}
	}
}
