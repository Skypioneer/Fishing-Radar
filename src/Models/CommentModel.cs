using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Comment model used to create comments on individual cards.
    /// </summary>
    public class CommentModel
    {
        // The ID for this comment, use a Guid so it is always unique
        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        // The Comment
        public string Comment { get; set; }
    }
}