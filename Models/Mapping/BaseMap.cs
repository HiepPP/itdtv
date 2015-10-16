using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ssc.consulting.switchboard.Models.Mapping
{
    public class BaseMap<T> : EntityTypeConfiguration<T> where T : Base
    {
        protected BaseMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Position).IsRequired();
            this.Property(t => t.IsActive).IsRequired();
            this.Property(t => t.Created).IsRequired();
            this.Property(t => t.IsDeleted).IsRequired();

            // Table & Column Mappings
            this.ToTable(string.Format("{0}", typeof(T).Name));
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Position).HasColumnName("Position");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}