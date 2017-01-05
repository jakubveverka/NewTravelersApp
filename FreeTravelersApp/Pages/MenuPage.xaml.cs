using System.Collections.Generic;
using Xamarin.Forms;

namespace FreeTravelersApp.Pages
{
    public partial class MenuPage : ContentPage
    {
		public ListView ListView { get { return listView; } }

		ListView listView;

        public MenuPage()
        {
            InitializeComponent();      

			var menuPageItems = new List<FreeTravelersApp.ListViewItems.MenuItem>();
			menuPageItems.Add(new FreeTravelersApp.ListViewItems.MenuItem
			{
				Text = "Prohlídky",
				TargetType = typeof(LocationsPage)
			});
			menuPageItems.Add(new FreeTravelersApp.ListViewItems.MenuItem
			{
				Text = "Průvodci",
				TargetType = typeof(UsersListPage)
			});
			menuPageItems.Add(new FreeTravelersApp.ListViewItems.MenuItem
			{
				Text = "Profil",
				TargetType = typeof(ProfilPage)
			});
			menuPageItems.Add(new FreeTravelersApp.ListViewItems.MenuItem
			{
				Text = "Zprávy",
				TargetType = typeof(ConditionsPage)
			});
			menuPageItems.Add(new FreeTravelersApp.ListViewItems.MenuItem
			{
				Text = "Nápověda",
				TargetType = typeof(ConditionsPage)
			});
			menuPageItems.Add(new FreeTravelersApp.ListViewItems.MenuItem
			{
				Text = "Podmínky",
				TargetType = typeof(ConditionsPage)
			});

			listView = new ListView
			{
				ItemsSource = menuPageItems,
				ItemTemplate = new DataTemplate(() =>
				{
					var textCell = new TextCell();
					textCell.TextColor = Color.Black;
					textCell.SetBinding(TextCell.TextProperty, "Text");
					return textCell;
				}),
				VerticalOptions = LayoutOptions.FillAndExpand,
				SeparatorVisibility = SeparatorVisibility.None
			};

			Padding = new Thickness(0, 40, 0, 0);
			Icon = "hamburger.png";
			Title = "Menu";
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					listView
				}
			};
        }
    }
}
