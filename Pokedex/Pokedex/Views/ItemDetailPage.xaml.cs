/*
**********************
* Author: luisduenas * 
* Date: May 31 2017  *
**********************
 */
using Pokedex.ViewModels;
using Xamarin.Forms;

namespace Pokedex.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		ItemDetailViewModel viewModel;
        public ItemDetailPage()
        {
            InitializeComponent();
        }
        public ItemDetailPage(ItemDetailViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = this.viewModel = viewModel;
		}
    }
}
