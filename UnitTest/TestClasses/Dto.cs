using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.TestClasses
{
	internal class Dto
	{
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public string? NullableProperty { get; set; }
		public DateTime CreatedAt { get; set; }
		public string ExtraProperty { get; set; } = "Default"; // Should not be overwritten
	}
}
