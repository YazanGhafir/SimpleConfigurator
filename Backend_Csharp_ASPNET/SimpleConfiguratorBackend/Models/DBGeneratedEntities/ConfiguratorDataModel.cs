namespace SimpleConfiguratorBackend
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConfiguratorDataModel : DbContext
    {
        public ConfiguratorDataModel()
            : base("name=ConfiguratorDataModel")
        {
        }

        public virtual DbSet<DISALLOWED_PARAMETER> DISALLOWED_PARAMETER { get; set; }
        public virtual DbSet<DISALLOWED_RULE> DISALLOWED_RULE { get; set; }
        public virtual DbSet<DISALLOWED_VALUE> DISALLOWED_VALUE { get; set; }
        public virtual DbSet<PARAMETER> PARAMETERs { get; set; }
        public virtual DbSet<PARAMETER_VALUE> PARAMETER_VALUE { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DISALLOWED_RULE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMETER>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMETER_VALUE>()
                .Property(e => e.NAME)
                .IsUnicode(false);
        }
    }
}
