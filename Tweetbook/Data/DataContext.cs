using Microsoft.EntityFrameworkCore;
using Tweetbook.Domain;

namespace Tweetbook.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    public DbSet<Post> Posts { get; set; }
}