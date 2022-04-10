using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DatabaseAssets
    {
        public static string GetConnectionString()
        {
            var connString = "Data Source=QuizApp.db";
            return connString;
        }
    }
}
