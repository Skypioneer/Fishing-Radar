using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Index page (home page of the website)
    /// Yu Zhong 
    /// Francis Kogge
    /// Mark Taylor
    /// Jason Wang
    /// </summary>
    public class IndexModel : PageModel
    {
        // Performs logging
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService<PostModel> productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        // Helper field for performing actions on and getting the products list
        public JsonFileProductService<PostModel> ProductService { get; }
        // List of all products
        public IEnumerable<PostModel> Products { get; private set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}