//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineGame.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GamerDetail
    {
        public int Id { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public decimal GameMoney { get; set; }
    
        public virtual Gamer2 Gamer2 { get; set; }
    }
}
