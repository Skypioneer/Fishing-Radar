using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

//change that im going to stash- mark
namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Error model class to handle error page
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        // The Id to show, bind to it for the post
        public string RequestId { get; set; }

        // check if the Id existed in the list
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Performs logging
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// Default Constructor with a logger for logging the error happenend
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Sets the requestID from the current activity ID
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}