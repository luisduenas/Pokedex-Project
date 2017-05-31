/*
**********************
* Author: luisduenas * 
* Date: May 31 2017  *
**********************
 */
using Pokedex.Helpers;
using Pokedex.Models;
using Pokedex.Services;

using Xamarin.Forms;

namespace Pokedex.ViewModels
{
	public class BaseViewModel : ObservableObject
	{
		public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
		bool isBusy = false;
		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}
		string title = string.Empty;
		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value); }
		}
	}
}

