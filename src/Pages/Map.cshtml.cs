using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages
{   
    /// <summary>
    /// Map Page that will show an embedded map of fishing locations.
    /// </summary>
    public class MapModel : PageModel
    {

        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
        }
    }
}
