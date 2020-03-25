using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace PhotowalaWebsite.Models
{
    public class Work
    {
        public int WorkId { get; set; }
        [StringLength(500)]

        public string Title { get; set; }
        [StringLength(150)]

        public string ImagePath { get; set; }
        [StringLength(500)]

        public string Description { get; set; }
        [StringLength(150)]

        public string Tag { get; set; }

        public string Link { get; set; }

    }
}