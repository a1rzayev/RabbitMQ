using RabbitMQAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RabbitMQAPI.Database;

public class RabbitMQDbContext : DbContext
{
    public RabbitMQDbContext(DbContextOptions<RabbitMQDbContext> options) : base(options) {}
    
    public DbSet<Post> Posts { get; set; }
}