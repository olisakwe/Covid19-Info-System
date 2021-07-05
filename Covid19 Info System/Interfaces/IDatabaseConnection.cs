using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19_Info_System.Interfaces
{
    public interface IDatabaseConnection
{
        SQLite.SQLiteAsyncConnection DbConnection();
    }
}
