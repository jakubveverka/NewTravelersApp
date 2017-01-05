using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FreeTravelersApp.ViewModels;

namespace FreeTravelersApp.Pages
{
	public class ProfilPage : ContentPage
	{
		public ProfilPage(int userId = 1093)
		{
			var layout = new StackLayout();
			var scrollView = new ScrollView();
			var listContent = new StackLayout();

			scrollView.Content = listContent;

			var usersViewModel = new UsersViewModel();
			usersViewModel.GetUserAsync(listContent, userId.ToString());

			layout.Children.Add(scrollView);
			Content = layout;
		}

	}
}
