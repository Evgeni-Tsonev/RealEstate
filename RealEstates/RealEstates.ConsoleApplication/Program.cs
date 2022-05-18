using Microsoft.EntityFrameworkCore;
using RealEstates.Data;

class Program
{
    static void Main()
    {
        var db = new ApplicationDbContext();
        db.Database.Migrate();
    }
}
