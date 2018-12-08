using System;
using System.ComponentModel.DataAnnotations;

namespace Conferences.DataAccess.Entities
{
    public class Products
    {
        [Key]
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public string ProductDescription { get; set; }
    }
}
