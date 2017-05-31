/*
**********************
* Author: luisduenas * 
* Date: May 31 2017  *
**********************
 */
using Pokedex.Models;

namespace Pokedex.ViewModels
{
	public class ItemDetailViewModel : BaseViewModel
	{
		public Item Item { get; set; }
		public ItemDetailViewModel(Item item = null)
		{
			Title = item.Name;
			Item = item;
		}
		int quantity = 1;
		public int Quantity
		{
			get { return quantity; }
			set { SetProperty(ref quantity, value); }
		}
	}
}