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
    
    public partial class GamerSkill
    {
        public int GamerId { get; set; }
        public int SkillId { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual Gamer2 Gamer2 { get; set; }
        public virtual Skill Skill { get; set; }
    }
}