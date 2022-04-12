using ApiTest.Controllers;
using ApiTest.Models;
using ApiTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class BeerTesting
    {
        private readonly BeerController _controller;
        private readonly IBeerService _service;


        public BeerTesting()
        {
            _service = new BeerService();
            _controller = new BeerController(_service); 
        }

        [Fact]
        public void GetOk()
        {
            var result = _controller.Get();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetQuantity()
        {
            var result = (OkObjectResult)_controller.Get();

            var beers = Assert.IsType<List<Beer>>(result.Value);
            Assert.True(beers.Count > 0);
        }

        [Fact]
        public void GetByIdOk()
        {
            int id = 1;

           var result = _controller.Get(id);

            Assert.IsType<OkObjectResult>(result);  
        }

        [Fact]
        public void GetById_Exists()
        {
            //Arrange
            int id = 1;

            //Act
            var result = (OkObjectResult) _controller.Get(id);

            //Assert
            var beer = Assert.IsType<Beer>(result?.Value);
            Assert.True(beer != null);
            Assert.Equal(beer?.Id, id);
        }

        [Fact]
        public void GetById_NotFound()
        {
            //Arrange
            int id = 11;

            //Act
            var result =_controller.Get(id);

            //Assert
            var beer = Assert.IsType<NotFoundResult>(result);
        }
    }
}