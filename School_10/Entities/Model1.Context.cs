﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace School_10.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class School10Entities : DbContext
    {
        public School10Entities()
            : base("name=School10Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Klassi> Klassis { get; set; }
        public virtual DbSet<Predmeti> Predmetis { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Ucheniki> Uchenikis { get; set; }
        public virtual DbSet<Uroki> Urokis { get; set; }
        public virtual DbSet<Uroki_Ucheniki> Uroki_Ucheniki { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
