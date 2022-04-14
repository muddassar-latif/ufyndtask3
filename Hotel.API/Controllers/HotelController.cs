using Hotel.Contracts.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hotel.API.Controllers
{
	public class HotelController : BaseApiController
	{
		private IHotelRepository _repository;

		public HotelController(IHotelRepository hotelRepository)
		{
			_repository = hotelRepository;
		}

		[HttpGet]
		[ExceptionFilter]
		public async Task<IHttpActionResult> GetHotelRates(int hotelId, DateTime? arrivalDate = null)
		{
			var hotel = await _repository.GetHotelRates(hotelId, arrivalDate);
			if (hotel == null)
				return NotFound();
			return Ok(hotel);
		}
	}
}
