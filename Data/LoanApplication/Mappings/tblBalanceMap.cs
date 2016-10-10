using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class tblBalanceMap : EntityTypeConfiguration<tblBalance>
    {
        public tblBalanceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsFixedLength()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblBalance");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Balance).HasColumnName("Balance");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
