using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Privacy Page
    /// Page will have sites privacy policy and related information
    /// </summary>
    public class PrivacyModel : PageModel
    {
        
        //Read only logger store information of the current status of
        //the privacy page
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Creates a logger object from of PrivacyModel class
        /// which can then be used to create logs
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {   
            //create logger instance. Currently not in use.
            _logger = logger;
        }

        /// <summary>
        /// REST Get request. Currently has no functionality
        /// </summary>
        public void OnGet()
        {
        }
    }
}