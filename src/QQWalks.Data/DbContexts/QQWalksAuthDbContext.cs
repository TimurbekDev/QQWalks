using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Data.DbContexts;

public class QQWalksAuthDbContext:IdentityDbContext
{
    public QQWalksAuthDbContext(DbContextOptions<QQWalksAuthDbContext> options):base(options)
    {   }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        string readerRoleId = "2da7e91a-6507-4f2a-974b-19bc995b78a7";
        string writerRoleId = "0ba60688-8e5d-44c0-9860-e44733f7bc9f";

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
            },
            new IdentityRole
            {
                Id = writerRoleId,
                ConcurrencyStamp = writerRoleId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}
