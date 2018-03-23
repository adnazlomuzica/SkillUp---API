﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SkillUpEntities : DbContext
    {
        public SkillUpEntities()
            : base("name=SkillUpEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<Odgovori> Odgovori { get; set; }
        public virtual DbSet<Pitanje> Pitanje { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<UradjeniTestovi> UradjeniTestovi { get; set; }
    
        public virtual ObjectResult<Kategorija_Result> su_SelectAllCategories()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Kategorija_Result>("su_SelectAllCategories");
        }
    
        public virtual ObjectResult<Test_Result> su_SelectTestsByCategory(Nullable<int> kategorijaID)
        {
            var kategorijaIDParameter = kategorijaID.HasValue ?
                new ObjectParameter("KategorijaID", kategorijaID) :
                new ObjectParameter("KategorijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Test_Result>("su_SelectTestsByCategory", kategorijaIDParameter);
        }
    }
}
