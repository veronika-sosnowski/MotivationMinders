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
        public Nullable<decimal> price { get; set; }
        public Nullable<int> itemPar { get; set; }
        public Nullable<decimal> discountPrice { get; set; }
        public Nullable<int> stockQuantity { get; set; }
        public Nullable<bool> allowBackOrders { get; set; }
        public Nullable<double> weight { get; set; }
        public Nullable<System.TimeSpan> date { get; set; }
    
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
