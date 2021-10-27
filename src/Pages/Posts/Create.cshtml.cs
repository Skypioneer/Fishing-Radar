
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
        public ProductModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet()
        {
            Product = ProductService.CreateData();

            // Redirect the webpage to the Update page populated with
            // the data so the user can fill in required fields
            return RedirectToPage("./Update", new { Id = Product.Id });
        }
    }
}