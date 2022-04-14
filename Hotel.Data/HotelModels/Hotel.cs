using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.HotelModels
{
	public class Hotel
	{
		public int Classification { get; set; }
		public int HotelId { get; set; }
		public string Name { get; set; }
		public decimal ReviewScore { get; set; }
	}
}
