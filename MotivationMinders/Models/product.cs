//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MotivationMinders.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public product()
        {
            this.ProductImages = new HashSet<ProductImage>();
            this.ProductTags = new HashSet<ProductTag>();
        }
    
        public int productID { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string meaning { get; set; }
        public decimal price { get; set; }
    
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
