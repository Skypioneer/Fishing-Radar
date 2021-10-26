using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// AboutModel class to handle about page 
    /// </summary>
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;

        /// <summary>
        /// Default Constructor with a logger for logging info
        /// </summary>
        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///  Currently empty because no need of it yet
        /// </summary>
        public void OnGet()
        {
        }
    }
}
