using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// Controller responsible for interaction with the Products.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Initializes the JsonFileProductService field.
        /// </summary>
        /// <param name="productService">A JsonFileProductService instance</param>
        public ProductsController(JsonFileProductService<PostModel> productService)
        {
            ProductService = productService;
        }

        // Field for getting and performing actions on the product list
        public JsonFileProductService<PostModel> ProductService { get; }

        /// <summary>
        /// Http Get request
        /// Gets the collection of products.
        /// </summary>
        /// <returns>Enumerable collection of products</returns>
        [HttpGet]
        public IEnumerable<PostModel> Get()
        {
            return ProductService.GetAllData();
        }

        /// <summary>
        /// Http Patch request
        /// Adds a rating to the specified product. It finds the given product from
        /// the rating request.
        /// </summary>
        /// <param name="request">A RatingRequest instance</param>
        /// <returns>OkResult, indicating successful request</returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);
            
            return Ok();
        }

        /// <summary>
        /// Helper class for finding a product from its ProductID and Rating
        /// </summary>
        public class RatingRequest
        {
            // The product's ProductID
            public string ProductId { get; set; }
            // The product's Rating
            public int Rating { get; set; }
        }
    }
}