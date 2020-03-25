namespace PhotowalaWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class Image
    {
        public int ImageID { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        [StringLength(150)]
        public string Location { get; set; }

        [StringLength(250)]
        public string ImagePath { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [StringLength(1500)]
        public string Tag { get; set; }
        public string TeamName { get; set; }
        public string Position { get; set; }
    }
}
