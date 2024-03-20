using ems.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace ems.Persistence.Configuration;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Event> Event { get; set; }
    public DbSet<EventFiles> EventFiles { get; set; }
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
    }
}
