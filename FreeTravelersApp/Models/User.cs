using System;
namespace FreeTravelersApp.Models
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public bool IsGuide { get; set; }
		public DateTime? GuideFrom { get; set; }
		public int IdentityId { get; set; }

		public User()
		{
		}
	}
}
