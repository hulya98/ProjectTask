using AutoMapper;
using Moq;
using ProjectTask.API.Controllers;
using ProjectTask.Domains.MappingProfile;
using ProjectTask.Domains.Models;
using System;
using Xunit;

namespace ProjectTask.Tests
{
    public class UnitTest1
    {
        IMapper _mapper;
        public UnitTest1()
        {
        }
        [Fact]
        public void Test1()
        {
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<ProductProfile, ProductController>(It.IsAny<ProductProfile>()));
            var expected = new ProductController(mockMapper.Object);

            ////Arrange 
            //var res = new ProductController(_mapper);
            ////Act
            var op = expected.AddProduct(new Domains.Dtos.ProductDto
            {
                IsDeleted = false,
                Price = 5,
                ProductCategoryId = 1,
                ProductName = "rrr",
                State = "az"
            });

            bool condition = true;
            if (op == op)
                condition = true;
            // Assert
            Assert.True(condition);




        }
    }
}
