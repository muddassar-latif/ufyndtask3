using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Contracts
{
	public interface IDataReader<T> where T : class
	{
		Task<List<T>> ReadDataFromSource();
	}
}
