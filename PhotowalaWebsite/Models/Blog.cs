using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotowalaWebsite.Models
{
    public class Blog
    {
       

        [Key]
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public string LogDiscription { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
        public int? catgoryID { get; set; }
        public virtual Catagory Catagorys { get; set; }
    }
}