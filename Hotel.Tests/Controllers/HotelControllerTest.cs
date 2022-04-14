using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Hotel.API.Controllers;
using Hotel.Contracts;
using Hotel.Contracts.RepositoryContracts;
using Hotel.Data.HotelModels;
using Hotel.Data.HoteViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Hotel.Tests.Controllers
{
	[TestClass]
	public class HotelControllerTest
	{
		private Mock<IHotelRepository> mockHotelRepository;

		[TestMethod]
		public async Task GetHotel()
		{
			mockHotelRepository = new Mock<IHotelRepository>();

			var hotelController = new HotelController(mockHotelRepository.Object);
			var result = await hotelController.GetHotelRates(7294, new DateTime(2016, 03, 15)) as Task<HotelViewModel>;

			Assert.IsNull(result);
			if (result != null)
			{
				Assert.AreEqual(result.Result.HotelId, 7294);
			}
		}
	}
}
