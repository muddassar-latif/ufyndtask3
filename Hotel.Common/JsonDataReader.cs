using Hotel.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Common
{
	public class JsonDataReader<T> : IDataReader<T> where T : class
	{
		public JsonDataReader()
		{

		}

		public async Task<List<T>> ReadDataFromSource()
		{
			return await LoadJsonFile();
		}

		private async Task<List<T>> LoadJsonFile()
		{
			var path = AppDomain.CurrentDomain.BaseDirectory + Constants.HotelRateJsonFile;

			var jsonData = await Task.Run(() =>
				JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path))
			);
			return jsonData;
		}
	}
}
