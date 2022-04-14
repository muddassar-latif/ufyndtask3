using Hotel.Data.HotelModels;
using Hotel.Data.HoteViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Contracts.RepositoryContracts
{
	public interface IHotelRepository
	{
		Task<HotelViewModel> GetHotelRates(int hotelId, DateTime? arrivalDate);
	}
}
