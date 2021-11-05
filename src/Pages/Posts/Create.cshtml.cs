
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Create Page model class is responsible
    /// for the creation of new cards (content) on our site
    /// </summary>
    public class CreateModel : PageModel
    {
        // Data middle tier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="productService"> </param>
        public CreateModel(JsonFileProductService productService)
        {
            // Product service acts as a mock database to pull data from
            ProductService = productService;
        }

        //ProductModel object for data creation
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet()
        {
            Product = ProductService.CreateData();
        }
    }
}