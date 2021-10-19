using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class myPostsModel : PageModel
    {
        private readonly ILogger<myPostsModel> _logger;

        public myPostsModel(ILogger<myPostsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
