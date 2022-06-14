using Microsoft.EntityFrameworkCore;

public class EmpContext : DbContext
{
    public EmpContext(DbContextOptions options) : base(options)
    {

    }
    DbSet<Employees> Employees { get; set; }
    //DbSet<HRData> HRData { get; set; }
}
