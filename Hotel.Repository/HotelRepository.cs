using Hotel.Common;
using Hotel.Contracts;
using Hotel.Contracts.RepositoryContracts;
using Hotel.Data.HotelModels;
using Hotel.Data.HoteViewModels;
using Mapster;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository
{
	public class HotelRepository : IHotelRepository
	{
		private IDataReader<HotelDetails> _dataReader;
		private List<HotelDetails> hotelDetails;
		private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

		public HotelRepository(IDataReader<HotelDetails> dataReader)
		{
			_dataReader = dataReader;
		}

		/// <summary>
		/// Get Hotel Rates
		/// </summary>
		/// <param name="hotelId"></param>
		/// <param name="arrivalDate"></param>
		/// <returns></returns>
		public async Task<HotelViewModel> GetHotelRates(int hotelId, DateTime? arrivalDate)
		{
			_logger.Trace(Constants.GetLogMessage(hotelId, arrivalDate));
			hotelDetails = await _dataReader.ReadDataFromSource();
			if (arrivalDate == null)
			{
				return GetHotelRatesByHotelId(hotelId);
			}
			return GetHotelRatesByHotelIdArrivalDate(hotelId, arrivalDate);
		}

		#region Private Members
		/// <summary>
		/// Get Hotel By Id
		/// </summary>
		/// <param name="hotelId"></param>
		/// <returns></returns>
		private HotelViewModel GetHotelRatesByHotelId(int hotelId)
		{
			var hotel = GetHotelByHotelId(hotelId);
			return ObjectMapper(hotel);
		}

		/// <summary>
		/// Get Hotel Data Model By Id
		/// </summary>
		/// <param name="hotelId"></param>
		/// <returns></returns>
		private HotelDetails GetHotelByHotelId(int hotelId)
		{
			var hotel = hotelDetails.Where(x => x.Hotel.HotelId == hotelId).FirstOrDefault();
			return hotel;
		}

		/// <summary>
		/// Get Hotel Rates with Hotel 
		/// </summary>
		/// <param name="hotelId"></param>
		/// <param name="arrivalDate"></param>
		/// <returns></returns>
		private HotelViewModel GetHotelRatesByHotelIdArrivalDate(int hotelId, DateTime? arrivalDate)
		{
			var hotel = GetHotelByHotelId(hotelId);
			if (hotel == null)
			{
				return ObjectMapper(hotel);
			}
			hotel.HotelRates = hotel.HotelRates.Where(x => x.TargetDay.Date == arrivalDate.Value.Date).ToList();
			return ObjectMapper(hotel);
		}

		/// <summary>
		/// Object Mapper
		/// </summary>
		/// <param name="hotelDetails"></param>
		/// <returns></returns>
		private HotelViewModel ObjectMapper(HotelDetails hotelDetails)
		{
			TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

			if(hotelDetails == null)
			{
				return null;
			}
			var hotelViewModel = hotelDetails.Hotel.Adapt<HotelViewModel>();
			hotelViewModel.HotelRates = hotelDetails.HotelRates.Adapt<List<HotelRateViewModel>>();
			return hotelViewModel;
		}
		#endregion
	}
}
