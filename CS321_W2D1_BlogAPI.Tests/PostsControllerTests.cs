using System;
using Xunit;
using CS321_W2D1_BlogAPI.Controllers;
using CS321_W2D1_BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;
using CS321_W2D1_BlogAPI.Models;

namespace CS321_W2D1_BlogAPI.Tests
{
    public class PostsControllerTests
    {
        [Fact]
        public void Get_ReturnsNotFound()
        {
            // Ensure that Get(id) returns NotFound status code if
            // the requested Post does not exist

            // arrange
            var controller = new PostsController(new PostService());

            // act - id 999 should not exist
            var result = controller.Get(999);

            // assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_ReturnsOk()
        {
            // Ensure that Get(id) returns Ok status if Post exists

            // arrange
            var controller = new PostsController(new PostService());

            // act - id 2 is in the seed data, should exist
            var result = controller.Get(2);

            // assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_NoContent()
        {
            // Ensure that Delete(id) returns No Content status if Delete if successful
            var controller = new PostsController(new PostService());

            //act - id 2 is in the seed data, should exist
            var result = controller.Delete(2);

            // assert
            Assert.IsType<NoContentResult>(result);
        }


        [Fact]
        public void Post_CreatedAtAction()
        {
            var controller = new PostsController(new PostService());

            Post post = new Post { Id = 3, Title = "kasdj", Body = "asflj" };

            var result = controller.Post(post);

            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public void Put_NotFound()
        {
            var controller = new PostsController(new PostService());

            Post post = new Post { Id = 4, Title = "kasdflj", Body = "asdflj" };

            var result = controller.Put(4, post);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Put_OkObject()
        {
            var controller = new PostsController(new PostService());

            Post post = new Post { Id = 2, Title = "kasdflj", Body = "asdflj" };

            var result = controller.Put(2, post);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
