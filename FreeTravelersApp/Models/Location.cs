using System;
namespace FreeTravelersApp.Models
{
	public class Location
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Description { get; set; }
		public String RegisterDate { get; set; }
		public User Creator { get; set; }
		public String CreatorId { get; set; }
		public String CategoryId { get; set; }

		public Location()
		{
		}
	}
}
