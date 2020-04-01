namespace SimpleConfiguratorBackend
{
    using System;
    using System.Data.Entity;

    public partial class ConfiguratorDataModel : DbContext
    {
        public ConfiguratorDataModel()
            : base("name=ConfiguratorDataModel")
        {
        }

        public virtual DbSet<DISALLOWED_PARAMETER> DISALLOWED_PARAMETER { get; set; }
        public virtual DbSet<DISALLOWED_RULE> DISALLOWED_RULE { get; set; }
        public virtual DbSet<DISALLOWED_VALUE> DISALLOWED_VALUE { get; set; }
        public virtual DbSet<PARAMETER> PARAMETER { get; set; }
        public virtual DbSet<PARAMETER_VALUE> PARAMETER_VALUE { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }


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

        public DbSet getEntityManager(string name)
        {
            switch(name)
            {
                case "PRODUCT":
                    return PRODUCT;
                case "PARAMETER":
                    return PARAMETER;
                case "PARAMETER_VALUE":
                    return PARAMETER_VALUE;
                case "DISALLOWED_RULE":
                    return DISALLOWED_RULE;
                case "DISALLOWED_PARAMETER":
                    return DISALLOWED_PARAMETER;
                case "DISALLOWED_VALUE":
                    return DISALLOWED_VALUE;
                default:
                    throw new FieldAccessException();
            }
        }
    }
}
