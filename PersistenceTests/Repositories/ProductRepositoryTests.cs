using AutoMapper;
using Fashion.Domain;
using Fashion.Domain.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Persistence.Repositories.Tests
{
    [TestClass()]
    public class ProductRepositoryTests
    {
        private readonly IUnitOfWork _maper;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProductRepository _productService;
        private readonly FashionStoresContext _dbContext;

        public ProductRepositoryTests()
        {
            _dbContext = new FashionStoresContext();
            _maper = new UnitOfWork(_dbContext);
            _mapperMock = new Mock<IMapper>();
            _productService = new ProductRepository(_maper, _mapperMock.Object);
        }
        [TestMethod()]
        public void ProductRepositoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindAllTest()
        {
            try
            {
                var res = _productService.FindAll(new Fashion.Domain.DTOs.Entities.Product.OptionFilter
                {
                    PageIndex = 1,
                    PageSize = 10,
                });
                Assert.IsNotNull(res);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void FindByIdTest()
        {
            try
            {
                var res = _productService.FindById(new Guid());
                Assert.AreEqual(1,1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}