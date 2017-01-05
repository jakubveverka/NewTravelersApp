using System;
namespace FreeTravelersApp.Models
{
	public class Visit
	{
		public int Id { get; set; }
		public string VisitorId { get; set; }
		public string GuideId { get; set; }
		public string LocationId { get; set; }
		public string Date { get; set; }

		public Visit()
		{
		}
	}
}
