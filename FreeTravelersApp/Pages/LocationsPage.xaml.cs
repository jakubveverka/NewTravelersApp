using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FreeTravelersApp.Pages
{
	public partial class LocationsPage : ContentPage
	{
		public LocationsPage()
		{
			var layout = new StackLayout();
			var scrollView = new ScrollView();
			var listContent = new StackLayout();

			scrollView.Content = listContent;

			var locationsViewModel = new LocationsViewModel();
			locationsViewModel.GetLocationsAsync(listContent, GoToLocationDetailPage);

			layout.Children.Add(scrollView);
			Content = layout;
		}

		public void GoToLocationDetailPage(int locationId)
		{
			Navigation.PushAsync(new LocationDetailPage(locationId));
		}
	}
}
