using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.DAL.Concrete;
using SpoilBlock.Models;
using System.Net.Http;
using Moq.Contrib.HttpClient;

namespace SpoilBlock_Tests
{
    public  class RAWGGameSearchServiceTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void RAWGGameSearchService_Should_ReturnEmptyListIfNoResult()
        {
            //Arrange
            RAWGGameSearchService service = new RAWGGameSearchService(new Mock<IHttpClientFactory>().Object, new APIKeyAccessor(""));

            //Act
            List<GameEntry> actual = service.ParseRAWGJSON().ToList();

            //Assert that GameEntry list count is 0 i.e; it is empty.
        }

        public void RAWGGameSearchService_Should_ReturnCorrectlyIntepretJSON()
        {
            //Arrange
            RAWGGameSearchService service = new RAWGGameSearchService(new Mock<IHttpClientFactory>().Object, new APIKeyAccessor(""));

            //Act
            List<GameEntry> expected = service.ParseRAWGJSON().ToList();

            //Assert that actual list is equal to the expected fake list
        }

        public void RAWGGameSearchService_Should_ThrowNullArgumentException_IfJSONIsNull()
        {
            //Arrange
            RAWGGameSearchService service = new RAWGGameSearchService(new Mock<IHttpClientFactory>().Object, new APIKeyAccessor(""));
            

            //Assert throw NullArgumentException when JSON is null
        }
    }
