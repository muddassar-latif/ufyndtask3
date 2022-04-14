using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Contracts;
using Hotel.Contracts.RepositoryContracts;
using Hotel.Data.HotelModels;
using Hotel.Data.HoteViewModels;
using Hotel.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Hotel.Tests.Repository
{
	[TestClass]
	public class HotelRepositoryTest
	{
		//private Mock<IDataReader<HotelDetails>> mockDataReader;

		public HotelRepositoryTest()
		{
		}

		[TestMethod]
		public async Task GetHotelDetailsTypeIsEqualToHotelViewModel()
		{
			var mockDataReader = new Mock<IDataReader<HotelDetails>>();
			mockDataReader.Setup(x => x.ReadDataFromSource()).Returns(getFakeData());

			var mock = new Mock<IHotelRepository>();

			var repository = new HotelRepository(mockDataReader.Object);
			var result = await repository.GetHotelRates(7294, null);
			Assert.AreEqual(result.GetType(), typeof(HotelViewModel));
		}


		[TestMethod]
		public async Task GetHotelDetailsIfCorrectInputProvided()
		{
			var mockDataReader = new Mock<IDataReader<HotelDetails>>();
			mockDataReader.Setup(x => x.ReadDataFromSource()).Returns(getFakeData());

			var mock = new Mock<IHotelRepository>();

			var repository = new HotelRepository(mockDataReader.Object);
			var result = await repository.GetHotelRates(7294, null);
			Assert.AreEqual(result.HotelId, 7294);
		}


		[TestMethod]
		public async Task GetHotelDetailsIfWrongInputProvided()
		{
			var mockDataReader = new Mock<IDataReader<HotelDetails>>();
			mockDataReader.Setup(x => x.ReadDataFromSource()).Returns(getFakeData());

			var mock = new Mock<IHotelRepository>();

			var repository = new HotelRepository(mockDataReader.Object);
			var result = await repository.GetHotelRates(7295, null);
			Assert.IsNull(result);
		}

		private Task<List<HotelDetails>> getFakeData()
		{
			return Task.FromResult(new List<HotelDetails>(){  new HotelDetails()
			{
				Hotel = new Data.HotelModels.Hotel() { Classification = 5, Name = "Kempinski Bristol Berlin", HotelId = 7294, ReviewScore = 8.3M },
				HotelRates = new List<HotelRate>()
					{
						new HotelRate() { Adults = 2, LOS = 1, TargetDay = new DateTime(2016,03,15) }
					},
			} });
		}
	}
}
