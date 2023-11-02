using Microsoft.EntityFrameworkCore;
using CarStocksApi.Models;

namespace CarStocksApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Car> Cars { get; set; } = null!;
}