using Dapper;
using TestUtil.Mothers;
using Moq;
using Moq.Dapper;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.Dapper.Unit.Tests
{
    public class CallingGetProductsByCategoryId : ProductTestBase
    {
        private Task<IEnumerable<Core.Entities.Product>> _result;

        [SetUp]
        public void SetUp()
        {
            ConnectionMock.SetupDapperAsync(x => x.QueryAsync<Core.Entities.Product>(It.IsAny<string>(), It.IsAny<object>(), null, null, null)).ReturnsAsync(ProductSamples.OfCategory);
            
            Assert.DoesNotThrow(() => _result = UnderTest.GetProductsByCategoryId(1));
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(ProductSamples.OfCategory);
        }
    }

    public class CallingGetFeatured : ProductTestBase
    {
        private Task<IEnumerable<Core.Entities.Product>> _result;

        [SetUp]
        public void SetUp()
        {
            ConnectionMock.SetupDapperAsync(x => x.QueryAsync<Core.Entities.Product>(It.IsAny<string>(), null, null, null, null)).ReturnsAsync(ProductSamples.Featured);
            
            Assert.DoesNotThrow(() => _result = UnderTest.GetFeaturedProducts());
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(ProductSamples.Featured);
        }
    }

    public abstract class ProductTestBase
    {
        protected Mock<IDbConnection> ConnectionMock { get; private set; }

        protected Dapper.Product UnderTest { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ConnectionMock = new Mock<IDbConnection>();
            UnderTest = new Dapper.Product(ConnectionMock.Object);
        }
    }
}
