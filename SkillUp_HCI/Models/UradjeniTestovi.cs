//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SkillUp_HCI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UradjeniTestovi
    {
        public int UradjeniTest { get; set; }
        public int TestID { get; set; }
        public int KorisnikID { get; set; }
        public double Rezultat { get; set; }
    
        public virtual Korisnici Korisnici { get; set; }
        public virtual Test Test { get; set; }
    }
}
