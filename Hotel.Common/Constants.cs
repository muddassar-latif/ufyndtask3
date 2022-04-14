using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Common
{
	public static class Constants
	{
		public const string HotelRateJsonFile = "App_Data\\HotelRates.json";

		public static string GetLogMessage(int hotelId, DateTime? arrivalDate)
		{
			if (!arrivalDate.HasValue)
				return string.Format("HotelId : {0}", hotelId);
			return string.Format("HotelId : {0} - ArrivalTime : {1}", hotelId, arrivalDate);
		}
	}
}
