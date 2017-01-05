using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using FreeTravelersApp.Models;
                      
namespace FreeTravelersApp.ViewModels
{
	public class UsersViewModel
	{
		Network network;

		public UsersViewModel()
		{
			network = new Network();
		}

		public async Task<List<User>> GetUsers()
		{
			string url = "http://freetravelers.gear.host/User/GetAll";
			return await network.FetchResponseAsync<List<User>>(url);
		}

		public async void GetUsersAsync(Layout<View> container)
		{
			var users = await network.WaitRequest(container, GetUsers);
			if (users != null)
			{
				foreach (var user in users)
				{
					container.Children.Add(new Frame() { Content = new Label() { Text = string.Format("{0} {1} {2}", user.Id, user.FirstName, user.LastName) } });
				}
			}
		}

		public async void GetUserAsync(Layout<View> container, string userId)
		{
			var user = await network.WaitRequest(container, () => GetUser(userId));
			if (user != null)
			{
				container.Children.Add(new Frame() { Content = new Label() { Text = string.Format("{0} {1} {2}", user.Id, user.FirstName, user.LastName) } });
			}
		}

		public async Task<User> GetUser(string id)
		{
			string url = "http://freetravelers.gear.host/User/Get/" + id;
			return await network.FetchResponseAsync<User>(url);
		}

		public async void CreateUser(User user)
		{
			var url = string.Format("http://freetravelers.gear.host/User/Create");
			/*await*/
			network.PostRequestAsync(url, user, u => u.FirstName, u => u.LastName);
		}

		public async void DeleteUser(User user)
		{
			var url = string.Format("http://freetravelers.gear.host/User/Delete");
			using (var client = new HttpClient())
			{
				try
				{
					await client.DeleteAsync(url + "/" + user.Id);
				}
				catch (HttpRequestException ex)
				{
					;
				}
			}
		}

		public async void DeleteAllUsers()
		{
			var url = string.Format("http://freetravelers.gear.host/User/DeleteAll");
			/*await*/
			network.PostRequestAsync<object>(url, null);
		}
	}
}
