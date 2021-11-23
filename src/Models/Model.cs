using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Interface for Model classes.
    /// </summary>
    public interface Model
    {
        /// <summary>
        /// Returns the json file name that stores data for the 
        /// specific Model class.
        /// </summary>
        /// <returns>File name</returns>
        public string GetFileName();
    }
}
