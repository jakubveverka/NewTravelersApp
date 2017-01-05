using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using FreeTravelersApp.Models;
using System;

namespace FreeTravelersApp
{
	public class LocationsViewModel
	{
		Network network;

		public LocationsViewModel()
		{
			network = new Network();
		}

		public async Task<List<Location>> GetLocations()
		{
			string url = "http://freetravelers.gear.host/Location/GetAll";
			return await network.FetchResponseAsync<List<Location>>(url);
		}

		public async void GetLocationsAsync(Layout<View> container, Action<int> GoToLocationDetail)
		{
			var locations = await network.WaitRequest(container, GetLocations);
			if (locations != null)
			{
				foreach (var location in locations)
				{
					Label label = new Label() { Text = string.Format("{0} | {1} | {2}. {3}", location.Name, location.Address, location.Creator.FirstName[0], location.Creator.LastName) };
					label.GestureRecognizers.Add(new TapGestureRecognizer((view) => GoToLocationDetail(location.Id)));
					container.Children.Add(new Frame() { Content = label });
				}
			}
		}

		public async Task<Location> GetLocation(int locationId)
		{
			string url = "http://freetravelers.gear.host/Location/Get/"+locationId;
			return await network.FetchResponseAsync<Location>(url);
		}

		public async Task<Location> GetLocationAsync(Layout<View> container, int locationId)
		{
			var location = await network.WaitRequest(container, () => GetLocation(locationId));
			if (location != null)
			{
				container.Children.Add(new Label() { Text = string.Format("Název: {0}", location.Name) });
				container.Children.Add(new Label { Text = string.Format("Popisek: {0}", location.Description) });
				container.Children.Add(new Label() { Text = string.Format("Vytvořil: {0} {1}", location.Creator.FirstName, location.Creator.LastName) });
				container.Children.Add(new Label() { Text = string.Format("Adresa: {0}", location.Address) });
				container.Children.Add(new Label() { Text = string.Format("Registrováno: {0}", location.RegisterDate.ToString()) });
			}
			return location;
		}

		public async void CreateLocation(String name, String address, String desctiption)
		{
			var url = "http://freetravelers.gear.host/Location/Create";
			var location = new Location() { Name = name, Address = address, Description = desctiption, CreatorId = "1093", RegisterDate = DateTime.Now.ToString(), CategoryId = "1" };
			await network.PostRequestAsync(url, location, l => l.Name, l => l.Address, l => l.Description, l => l.CreatorId, l => l.RegisterDate, l => l.CategoryId);
		}

		public async void CreateVisit(int userId, int guideId, int locationId, string date)
		{
			var url = "http://freetravelers.gear.host/Visit/Create";
			var visit = new Visit() { VisitorId = userId.ToString(), GuideId = guideId.ToString(), LocationId = locationId.ToString(), Date = date };
			await network.PostRequestAsync(url, visit, v => v.VisitorId, v => v.GuideId, v => v.LocationId, v => v.Date);
		}
 
	}
}
