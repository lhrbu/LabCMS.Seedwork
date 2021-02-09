using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LabCMS.Seedwork
{
    internal class RepositoryDesignFactory:IDesignTimeDbContextFactory<Repository>
    {
        public Repository CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<Repository> optionsBuilder = new ();
            optionsBuilder.UseNpgsql("Host=localhost;Database=Repository;");
            return new(optionsBuilder.Options);
        }
    }
}