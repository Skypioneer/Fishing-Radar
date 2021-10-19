using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class MyPostsModel : PageModel
    {


        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        private readonly ILogger<MyPostsModel> _logger;

        public MyPostsModel(ILogger<MyPostsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
