using AuditLogging.Core.Persistence;
using AuditLogging.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuditLogging.Contexts
{
    public class AuditDbCtx : DbContext
    {
        public AuditDbCtx(DbContextOptions<AuditDbCtx> options) : base(options)
        {
        }

        public DbSet<TestRootObj> TestRootObjs { get; set; }

        public DbSet<AuditLogEntry> Audits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

    class TestRootObjConfig : IEntityTypeConfiguration<TestRootObj>
    {
        public void Configure(EntityTypeBuilder<TestRootObj> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ComplexProperty(x => x.ComplexObj,
                p =>
                {
                    p.Property(x => x.Name);
                    p.Property(x => x.Value);
                });

            builder.HasMany(x => x.InnerObjs)
                .WithOne()
                .HasForeignKey("RId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    class InnerObjConfig : IEntityTypeConfiguration<InnerObj>
    {
        public void Configure(EntityTypeBuilder<InnerObj> builder)
        {
            builder.HasKey(e => e.Id);


            builder.Property<int>("RId");
        }
    }

    class AuditEntityConfig : IEntityTypeConfiguration<AuditLogEntry>
    {
        public void Configure(EntityTypeBuilder<AuditLogEntry> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(x => x.EntityId);

            builder.HasMany(x => x.Properties)
                .WithOne()
                .HasForeignKey("EntryId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    class AuditPropertyEntityConfig : IEntityTypeConfiguration<AuditProperty>
    {
        public void Configure(EntityTypeBuilder<AuditProperty> builder)
        {
            builder.Property<Guid>("EntryId");
        }
    }
}
