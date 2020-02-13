using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace myApi.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-194GH2V\\SQLEXPRESS;Initial Catalog=dbApi;Persist Security Info=True;User ID=rpbm;Password=rsp060683");
            return new MyContext(optionsBuilder.Options);
        }
    }
}
