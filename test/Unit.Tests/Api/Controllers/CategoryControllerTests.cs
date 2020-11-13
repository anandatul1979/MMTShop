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
    public class CallingControllerGetAll
    {
        public Mock<ILogger<CategoryController>> LoggerMock { get; private set; }
        public Mock<ICategory> CategoryMock { get; private set; }
        public CategoryController UnderTest { get; private set; }

        private Task<IEnumerable<Category>> _result;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            LoggerMock = new Mock<ILogger<CategoryController>>();
            CategoryMock = new Mock<ICategory>();
            UnderTest = new CategoryController(LoggerMock.Object, CategoryMock.Object);
        }

        [SetUp]
        public void SetUp()
        {
            CategoryMock.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(CategorySamples.All));
            Assert.DoesNotThrow(() => _result = UnderTest.GetAll());
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(CategorySamples.All);
        }

        [Test]
        public void ShouldUseCategory()
        {
            CategoryMock.Verify(x => x.GetAllAsync());
        }
    }   
}
