using DtoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.TestClasses;

namespace UnitTest
{
	public class MapperTests
	{
		[Fact]
		public void Map_Should_Copy_ReadOnly_Model_Properties_To_Dto()
		{
			// Arrange
			var model = new Model(1, "TestName", "NullableValue", new DateTime(2025, 1, 1));

			// Act
			var dto = Mapper.Map<Dto>(model);

			// Assert
			Assert.Equal(model.Id, dto.Id);
			Assert.Equal(model.Name, dto.Name);
			Assert.Equal(model.NullableProperty, dto.NullableProperty);
			Assert.Equal(model.CreatedAt, dto.CreatedAt);

			// ExtraProperty NOT overwritten
			Assert.Equal("Default", dto.ExtraProperty);
		}

		[Fact]
		public void Map_Should_Handle_Nullable_Properties()
		{
			// Arrange
			var model = new Model(2, "AnotherTest", null, new DateTime(2025, 2, 2));

			// Act
			var dto = Mapper.Map<Dto>(model);

			// Assert
			Assert.Null(dto.NullableProperty);
			Assert.Equal(model.Id, dto.Id);
			Assert.Equal(model.Name, dto.Name);
			Assert.Equal(model.CreatedAt, dto.CreatedAt);
		}

		[Fact]
		public void Map_Should_Create_New_Instance_Every_Time()
		{
			// Arrange
			var model = new Model(3, "InstanceTest", "Value", DateTime.Now);

			// Act
			var dto1 = Mapper.Map<Dto>(model);
			var dto2 = Mapper.Map<Dto>(model);

			// Assert
			Assert.NotSame(dto1, dto2);
			Assert.Equal(dto1.Id, dto2.Id);
			Assert.Equal(dto1.Name, dto2.Name);
			Assert.Equal(dto1.NullableProperty, dto2.NullableProperty);
		}

		[Fact]
		public void Map_Should_Copy_Different_DataTypes()
		{
			// Arrange
			var model = new Model(10, "DataTypeTest", "Value", new DateTime(2025, 11, 9));

			// Act
			var dto = Mapper.Map<Dto>(model);

			// Assert
			Assert.IsType<int>(dto.Id);
			Assert.IsType<string>(dto.Name);
			Assert.IsType<string>(dto.NullableProperty);
			Assert.IsType<DateTime>(dto.CreatedAt);
		}

		[Fact]
		public void Map_Should_Ignore_Extra_Properties_In_Dto()
		{
			// Arrange
			var model = new Model(5, "ExtraTest", "Value", DateTime.Now);

			// Act
			var dto = Mapper.Map<Dto>(model);

			// Assert
			// ExtraProperty should not be changed
			Assert.Equal("Default", dto.ExtraProperty);
		}

		[Fact]
		public void Map_Should_Skip_Incompatible_Types_Safely()
		{
			// Arrange
			var model = new Model(5, "ExtraTest", "Value", DateTime.Now);

			// Act
			var dto = Mapper.Map<DtoWithIdAsString>(model);

			// Assert
			Assert.Equal(model.Name, dto.Name);
			Assert.Equal(model.CreatedAt, dto.CreatedAt);
			Assert.Equal(model.NullableProperty, dto.NullableProperty);
			Assert.Equal(default, dto.Id);

			Assert.NotNull(dto);
		}

		/*
		 * 
		 * 		public string Id { get; set; } = "";
		public string Name { get; set; } = "";
		public string? NullableProperty { get; set; }
		public DateTime CreatedAt { get; set; }
		public string ExtraProperty { get; set; } = "Default"; // Should not be overwritten
		*/
	}
}
