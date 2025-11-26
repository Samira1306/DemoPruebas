using DemoPruebas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoPruebas.Infraestructure.Data.EFDbContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Users> Users { get; set; }
    #region JoinEntities
    public DbSet<ErrorLog> Errors { get; set; }
    #endregion
}
