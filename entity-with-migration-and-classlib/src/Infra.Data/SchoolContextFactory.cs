using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace aspnetcore_lab2.infra.data
{
    public class SchoolContextFactory : IDbContextFactory<SchoolContext>
    {
        public SchoolContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<SchoolContext>();
            builder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=ContosoUniversity3;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new SchoolContext(builder.Options);
        }
    }
}
