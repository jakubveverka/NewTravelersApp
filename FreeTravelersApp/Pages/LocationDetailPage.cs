using System;
using System.Collections.Generic;
using FreeTravelersApp.Models;

using Xamarin.Forms;

namespace FreeTravelersApp.Pages
{
	public class LocationDetailPage : ContentPage
	{
		public LocationDetailPage(int locationId)
		{
			GetLocation(locationId);
		}

		public async void GetLocation(int locationId)
		{
			var layout = new StackLayout();
			var scrollView = new ScrollView();
			var listContent = new StackLayout();

			scrollView.Content = listContent;

			layout.Children.Add(scrollView);

			var locationsViewModel = new LocationsViewModel();
			var location = await locationsViewModel.GetLocationAsync(listContent, locationId);
			var visitButton = new Button() { Text = "Navštívit" };
			visitButton.Clicked += (sender, e) =>
			{
				locationsViewModel.CreateVisit(1093, location.Creator.Id, locationId, DateTime.Now.ToString());
			};
			layout.Children.Add(visitButton);
			Content = layout;
		}
	}
}