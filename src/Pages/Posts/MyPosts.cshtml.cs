using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class MyPostsModel : PageModel
    {
        // Will act as data middleware
        public JsonFileProductService productService;

        /// <summary>
        /// Default Constructor for the MyPosts page
        /// </summary>
        /// <param name="productService"></param>
        public MyPostsModel(JsonFileProductService productService)
        {
            this.productService = productService;
        }
    }
}
