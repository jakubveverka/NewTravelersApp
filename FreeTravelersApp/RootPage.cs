using FreeTravelersApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace FreeTravelersApp
{
    public class RootPage : MasterDetailPage
    {
		MenuPage masterPage;

        public RootPage()
        {
            Detail = new NavigationPage(new WelcomePage());
			masterPage = new MenuPage();
			Master = masterPage;
            ShowLoginDialog();

			masterPage.ListView.ItemSelected += OnItemSelected;
        }

        private async void ShowLoginDialog()
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as FreeTravelersApp.ListViewItems.MenuItem;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}

    }
}
