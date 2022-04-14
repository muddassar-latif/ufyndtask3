using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.HotelModels
{
	public class HotelDetails
	{
		public Hotel Hotel { get; set; }

		public IEnumerable<HotelRate> HotelRates { get; set; }
	}
}
