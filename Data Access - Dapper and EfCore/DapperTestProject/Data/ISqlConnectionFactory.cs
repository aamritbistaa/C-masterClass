using System;
using System.Data;

namespace DapperTestProject.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
