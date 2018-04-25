using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assign2part3.Controllers;
using Assign2part3.Models;
using Moq;
using System.Linq;
using System.Web.Mvc;

namespace Assign2part3.Tests.Controllers
{
    [TestClass]
    public class GamesControllerTest
    {
        GamesController controller;
        Mock<IMockGamesRepository> mock;
        List<Game> games;

        [TestInitialize]

        public void InitialiseTest()
        {
            // instantiate new mock object
            mock = new Mock<IMockGamesRepository>();

            
            games = new List<Game>
            {
                new Game { GameId = 1, Country = "Country 1", Developer = "Developer 1" },
                new Game { GameId = 2, Country = "Country 2", Developer = "Developer 2" },
                new Game { GameId = 3, Country = "Country 3", Developer = "Developer 3" }
            };

            
            mock.Setup(g => g.Games).Returns(games.AsQueryable());

            // inject the mock dependency 
            controller = new GamesController(mock.Object);
        }

        [TestMethod]
        public void LoadINDEXView()
        {
            

            // act
            var x = controller.Index();

            //Assert

            Assert.IsNotNull(x);
        }
        [TestMethod]
        public void IndexLoadsGames()
        {
            
            var x = (List<Game>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(games, x);
        }
        [TestMethod]
        public void DetailsValidGameId()
        {
            // act
            var actual = ((ViewResult)controller.Details(1)).Model;

            // assert
            Assert.AreEqual(games[0], actual);
        }

        [TestMethod]
        public void DetailsInvalidGameId()
        {
            
            var actual = (ViewResult)controller.Details(5);

           
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DetailsNoGameId()
        {
            // act
            var actual = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }
        // GET: Edit
        [TestMethod]
        public void EditValidIDGET()
        {

            var x = ((ViewResult)controller.Edit(1)).Model;

            Assert.AreEqual(games[0], x);
        }
        [TestMethod]
        public void EditINValidIDGET()
        {

            var actual = (ViewResult)controller.Edit(5);
            Assert.AreEqual("Error", actual.ViewName);

        }

        [TestMethod]
        public void EditNOIDGET()
        {
            //assert
            int? id = null;
            //act
            var actual = (ViewResult)controller.Edit(id);
            Assert.AreEqual("Error", actual.ViewName);
        }

        //POST: Edit
        [TestMethod]
        public void VALIDEDITPOST()
        {
            //action
            var actual = (RedirectToRouteResult)controller.Edit(games[0]);

            //assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);

        }
        [TestMethod]
        public void INVALIDEDITPOST()
        {
            controller.ModelState.AddModelError("key", "unit test error");
            var actual = (ViewResult)controller.Edit(games[0]);
            
            Assert.AreEqual("Edit", actual.ViewName);
        }

        [TestMethod]
        public void CreateViewLoads()
        {
            var actual = (ViewResult)controller.Create();
            Assert.AreEqual("Create", actual.ViewName);
        }

        [TestMethod]

        public void CreatePostValid()
        {
            Game g = new Game
            {
                Country = "Country1",
                Developer = "Developer1"
            
            };
            //act
            var actual = (RedirectToRouteResult)controller.Create(g);

            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }
        [TestMethod]
        public void CreatePostInValid()
        {
            Game g = new Game
            {
                Country = "Country1",
                Developer = "Developer1"
            };
            controller.ModelState.AddModelError("key", "cannot add game");
            //act
            var actual = (ViewResult)controller.Create(g);
            Assert.AreEqual("Create", actual.ViewName);

        }
        //Get: Delete
        [TestMethod]

        public void DeleteGetValidId()
        {
            var actual = ((ViewResult)controller.Delete(1)).Model;
            Assert.AreEqual(games[0], actual);


        }

        [TestMethod]

        public void DeleteGetInvalidId()
        {
           // act

            var actual = (ViewResult)controller.Delete(5);
            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }
        [TestMethod]
        public void DeleteGetNoId()
        {
            // act

            var actual = (ViewResult)controller.Delete(null);
            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }
        [TestMethod]

        //Post:Delete

        public void ValidPOSTDelete()
        {

            var actual = (RedirectToRouteResult)controller.DeleteConfirmed(1);

           // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }
    }
}
