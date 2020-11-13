using Microsoft.Extensions.Logging;
using Api.Controllers;
using Core.DataAccess;
using Core.Entities;
using TestUtil.Mothers;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unit.Tests.Api.Controllers
{
    public class CallingGetProductsByCategoryId : BaseProductControllerTest
    {
        private Task<IEnumerable<Product>> _result;

        [SetUp]
        public void SetUp()
        {
            ProductMock.Setup(x => x.GetProductsByCategoryId(It.IsAny<int>()))
                .Returns(Task.FromResult(ProductSamples.OfCategory));
            Assert.DoesNotThrow(() => _result = UnderTest.GetProductsByCategoryId(1));
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(ProductSamples.OfCategory);
        }                

        [Test]
        public void ShouldUseProductReader()
        {
            ProductMock.Verify(x => x.GetProductsByCategoryId(It.IsAny<int>()));
        }
    }    
    
    public class CallingGetFeaturedProducts : BaseProductControllerTest
    {
        private Task<IEnumerable<Product>> _result;

        [SetUp]
        public void SetUp()
        {
            ProductMock.Setup(x => x.GetFeaturedProducts())
                .Returns(Task.FromResult(ProductSamples.Featured));
            Assert.DoesNotThrow(() => _result = UnderTest.GetFeaturedProducts());
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(ProductSamples.Featured);
        }                

        [Test]
        public void ShouldUseProductReader()
        {
            ProductMock.Verify(x => x.GetFeaturedProducts());
        }
    }

    public abstract class BaseProductControllerTest
    {
        public Mock<ILogger<ProductController>> LoggerMock { get; private set; }
        public Mock<IProduct> ProductMock { get; private set; }
        public ProductController UnderTest { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            LoggerMock = new Mock<ILogger<ProductController>>(); 
            ProductMock = new Mock<IProduct>();
            UnderTest = new ProductController(LoggerMock.Object, ProductMock.Object);
        }
    }
}
