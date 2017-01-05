using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XLabs;

namespace FreeTravelersApp
{
	public partial class AddLocationPage : ContentPage
	{
		public AddLocationPage()
		{
			var layout = new StackLayout();
			var nameEntry = new Entry() { Placeholder = "Název" };
			var addressEntry = new Entry() { Placeholder = "Adresa" };
			var descriptionEntry = new Entry() { Placeholder = "Popisek" };
			var createButton = new Button() { Text = "Vytvořit" };

			var locationViewModel = new LocationsViewModel();

			createButton.Clicked += (sender, e) =>
			{
				locationViewModel.CreateLocation(nameEntry.Text, addressEntry.Text, descriptionEntry.Text);
			};

			layout.Children.Add(nameEntry);
			layout.Children.Add(addressEntry);
			layout.Children.Add(descriptionEntry);
			layout.Children.Add(createButton);
			Content = layout;
		}
	}
}
