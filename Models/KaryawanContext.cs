using Microsoft.EntityFrameworkCore;

namespace KaryawanApi.Models
{
 public class KaryawanContext : DbContext
 {
   public KaryawanContext(DbContextOptions<KaryawanContext> options)
   : base(options)
   {
   }
    public DbSet<Karyawan> Karyawans{ get; set; }
  }
}