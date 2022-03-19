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
    public class AddToGamesWatchlistTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddToGamesWatchlist_Should_AddOneResult()
        {
            //Arrange
            var GameResults = new AddToGamesWatchlistService(new Mock<WOOPDbContext>.Object);

            //Act
            var actual = GameResults.AddToWatchlist().ToList();
            var expected = new List<Games>();

            // Assert that the added result, actual[1] == expected[1].
            
        }

        [Test]
        public void AddToGamesWatchlist_Should_AddMultipleResult()
        {
            //Arrange
            var GameResults = new AddToGamesWatchlistService(new Mock<WOOPDbContext>.Object);

            //Act
            var actual = GameResults.AddToWatchlist().ToList();
            var expected = new List<Games>();

            //Assert that the added result, All element are actual == expected.

        }

        [Test]
        public void AddToGamesWatchlist_Should_AddNoResult()
        {
            //Arrange
            var GameResults = new AddToGamesWatchlistService(new Mock<WOOPDbContext>.Object);

            //Act

            //Assert  a message that "Nothing is added to watchlist"
        }
    }
}
