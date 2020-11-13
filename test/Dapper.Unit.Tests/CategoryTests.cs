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
    public class CallingGetAllAsync 
    {
        private Task<IEnumerable<Core.Entities.Category>> _result;
        protected Mock<IDbConnection> ConnectionMock { get; private set; }

        protected Category UnderTest { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ConnectionMock = new Mock<IDbConnection>();
            UnderTest = new Category(ConnectionMock.Object);
        }

        [SetUp]
        public void SetUp()
        {
            ConnectionMock.SetupDapperAsync(x => x.QueryAsync<Core.Entities.Category>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(CategorySamples.All);
            
            Assert.DoesNotThrow(() => _result = UnderTest.GetAllAsync());
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(CategorySamples.All);
        }
    }

}
