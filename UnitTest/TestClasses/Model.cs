using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.TestClasses
{
	internal class Model
	{
		public int Id { get; }
		public string Name { get; }
		public string? NullableProperty { get; }
		public DateTime CreatedAt { get; }

		public Model(int id, string name, string? nullableProperty, DateTime createdAt)
		{
			Id = id;
			Name = name;
			NullableProperty = nullableProperty;
			CreatedAt = createdAt;
		}
	}
}
