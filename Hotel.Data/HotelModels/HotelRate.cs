using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.HotelModels
{
	public class HotelRate
	{
		public int Adults { get; set; }
		public int LOS { get; set; }
		public string RateDescription { get; set; }
		public string RateId { get; set; }
		public string RateName { get; set; }
		public DateTime TargetDay { get; set; }
		public HotelRatePrice Price { get; set; }
		public List<HotelRateTag> RateTags { get; set; }
	}
}
