using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FreeTravelersApp.ViewModels;
using FreeTravelersApp.Models;

namespace FreeTravelersApp
{
	public partial class UsersListPage : ContentPage
	{
		public UsersListPage()
		{
			var layout = new StackLayout();
			var scrollView = new ScrollView();
			var listContent = new StackLayout();

			scrollView.Content = listContent;

			var usersViewModel = new UsersViewModel();
			usersViewModel.GetUsersAsync(listContent);

			layout.Children.Add(scrollView);
			Content = layout;
		}
	}
}
