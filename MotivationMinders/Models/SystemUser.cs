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
    
    public partial class SystemUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public Nullable<int> Role { get; set; }
        public int userID { get; set; }
    }
}
