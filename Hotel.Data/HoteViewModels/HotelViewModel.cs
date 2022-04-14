using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.HoteViewModels
{
	public class HotelViewModel : IViewModel
	{
		public int Classification { get; set; }
		public int HotelId { get; set; }
		public string Name { get; set; }
		public decimal ReviewScore { get; set; }
		public List<HotelRateViewModel> HotelRates { get; set; }
	}
}
