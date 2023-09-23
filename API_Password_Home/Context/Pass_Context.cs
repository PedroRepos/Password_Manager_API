using API_Password_Home.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Password_Home.Context
{
    /// <summary>
    /// Define o contexto do banco de dados, SqlServer
    /// </summary>
    public class Pass_Context : DbContext
    {
        public Pass_Context(DbContextOptions<Pass_Context> options) : base (options)
        {
            
        }

        public DbSet<Data_Password_Services> Data_Password_Services { get; set; }
    }
}
