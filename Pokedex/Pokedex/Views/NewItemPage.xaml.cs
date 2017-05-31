using System;

using Pokedex.Models;

using Xamarin.Forms;

namespace Pokedex.Views
{
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }

		public NewItemPage()
		{
			InitializeComponent();
			Item = new Item
			{
				Name = "Item name",
				Description = "This is a nice description"
			};

			BindingContext = this;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                Device.OpenUri(new Uri(((Label)s).Text));
            };
            github.GestureRecognizers.Add(tapGestureRecognizer);
        }

		async void GoBack_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, "AboutUs", Item);
			await Navigation.PopToRootAsync();
		}
	}
}