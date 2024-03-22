using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure;

public class DbContext: IdentityDbContext<User>
{

    public DbContext()
    {

    }
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {

        // options.UseSqlite(
        //     $"Data Source={"D:\\Projects\\AudIT\\AudIT\\AudIT\\AudIT.Infrastructure\\database.db"}");

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            $"Data Source={"D:\\Projects\\CloudComputing\\CloudProject\\CloudProject\\Infrastructure\\cloud_db.db"}");
    }

}