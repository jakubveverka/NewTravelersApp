using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FreeTravelersApp
{
	public partial class LocationDetailPage : ContentPage
	{
		public LocationDetailPage(int locationId)
		{
			var layout = new StackLayout();
			var scrollView = new ScrollView();
			var listContent = new StackLayout();

			scrollView.Content = listContent;

			var locationsViewModel = new LocationsViewModel();
			locationsViewModel.GetLocationAsync(listContent, locationId);

			layout.Children.Add(scrollView);
			Content = layout;
		}
	}
}
