using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Prompt> Prompts { get; set; }
    public DbSet<CustomizedImage> CustomizedImages { get; set; }
    public DbSet<PromptCategory> PromptCategories { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Gift> Gifts { get; set; }
    public DbSet<Layer> Layers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<PackingSlip> PackingSlips { get; set; }
    public DbSet<Placement> Placements { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<RetailCost> RetailCosts { get; set; }
    public DbSet<Customization> Customizations { get; set; }
 
    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
