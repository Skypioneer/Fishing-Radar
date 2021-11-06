
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

        // ProductModel object for data creation
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Creates a new ProductModel data that can be added to
        /// JSON data set.
        /// </summary>
        /// <returns>ProductModel instance</returns>
        public ProductModel CreateData()
        {
            return new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };
        }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet()
        {
            Product = CreateData();
        }

        /// <summary>
        /// REST post request
        /// Saves the the newly created data to the JSON dataset via
        /// the ProductService attribute.
        /// </summary>
        /// <returns>Redirection to the home page</returns>
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            // Create and save the data to the JSON dataset
            ProductService.CreateData(Product);

            // After saving data, go back to the home page
            return RedirectToPage("../Index");
        }
    }
}