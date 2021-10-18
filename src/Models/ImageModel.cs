using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ContosoCrafts.WebSite.Models
{
    public class ImageModel
    {
        [System.ComponentModel.DataAnnotations.Key]

        /*ID for image uploaded*/
        public int ImageID { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }


        /*Unique Name for uploaded image*/
        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }
    }
}
