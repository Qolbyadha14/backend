using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class MyWorldDbContext : DbContext
{
    public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
    {

    }
    public DbSet<Transaction_bpkb> transaction_bpkb { get; set; }
    public DbSet<Storage_location> storage_location { get; set; }
}