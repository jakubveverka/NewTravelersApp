using System;
namespace FreeTravelersApp.Models
{
	public class Location
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Description { get; set; }
		public DateTime? RegisterDate { get; set; }
		public User Creator { get; set; }

		public Location()
		{
		}
	}
}
