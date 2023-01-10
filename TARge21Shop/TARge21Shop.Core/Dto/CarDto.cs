using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARge21Shop.Core.Dto
{
	public class CarDto
	{
		public Guid? Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string Color { get; set; }
		public string FuelType { get; set; }
		public int Price { get; set; }
		public int EnginePower { get; set; }
		public int Mileage { get; set; }
		public DateTime BuiltDate { get; set; }
		public DateTime MaintanceDate { get; set; }
	}
}
