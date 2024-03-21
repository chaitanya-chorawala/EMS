using ems.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace ems.Persistence.Configuration;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Event> Event { get; set; }
    public DbSet<EventMedia> EventMedia { get; set; }
    public DbSet<Registration> Registration { get; set; }
    public DbSet<FilePath> FilePath { get; set; }
    public DbSet<FormatConfiguration> FormatConfiguration { get; set; }
    public DbSet<JwtRefreshToken> UserJwtRefreshToken { get; set; }
    public DbSet<ServiceConfiguration> ServiceConfiguration { get; set; }
    public DbSet<MailMaster> MailMaster { get; set; }
    public DbSet<MailAttachment> MailAttachment { get; set; }
    public DbSet<APILogs> APILogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<EventDetail>().Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Entity<EventDetail>().Property(x => x.Longitude).HasPrecision(9, 6);

        builder.Entity<CancellationPolicy>().Property(x => x.CancellationValue).HasPrecision(18, 2);

        builder.Entity<Venue>().Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Entity<Venue>().Property(x => x.Longitude).HasPrecision(9, 6);

        builder.Entity<TicketCategory>().Property(x => x.IsPercentageOff).HasPrecision(18, 3);
        builder.Entity<TicketCategory>().Property(x => x.IsAmountOff).HasPrecision(18, 3);
        builder.Entity<TicketCategory>().Property(x => x.QuantitySold).HasPrecision(18, 3);

        builder.Entity<EventCostMaster>().Property(x => x.Cost).HasPrecision(18, 2);
        builder.Entity<EventCostMaster>().Property(x => x.MinimumSell).HasPrecision(18, 2);
        builder.Entity<EventCostMaster>().Property(x => x.RackRate).HasPrecision(18, 2);

        builder.Entity<CostMasterAuditLog>().Property(x => x.Cost).HasPrecision(18, 2);
        builder.Entity<CostMasterAuditLog>().Property(x => x.MinimumSell).HasPrecision(18, 2);
        builder.Entity<CostMasterAuditLog>().Property(x => x.RackRate).HasPrecision(18, 2);

        builder.Entity<EventTarrifWiseSellMaster>().Property(x => x.MarkupAmount).HasPrecision(18, 7);
        builder.Entity<EventTarrifWiseSellMaster>().Property(x => x.SellAmount).HasPrecision(18, 2);

        builder.Entity<EventAgentWiseSellMaster>().Property(x => x.MarkupAmount).HasPrecision(18, 7);
        builder.Entity<EventAgentWiseSellMaster>().Property(x => x.SellAmount).HasPrecision(18, 2);

        builder.Entity<EventSellMasterAuditLog>().Property(x => x.MarkupAmount).HasPrecision(18, 7);
        builder.Entity<EventSellMasterAuditLog>().Property(x => x.SellAmount).HasPrecision(18, 2);

        base.OnModelCreating(builder);
    }
}
