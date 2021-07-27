using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Common
{
    public class DBContextHelper:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (DbConfig.UseDB== "MySql")
            {
                optionsBuilder.UseMySQL(DbConfig.MySqlConStr);
            }
            else if (DbConfig.UseDB== "SqlServer")
            {
                optionsBuilder.UseSqlServer(DbConfig.SqlServerConStr);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
