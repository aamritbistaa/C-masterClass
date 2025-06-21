using System;

namespace BuildingBlocks.Middleware;

public class DatabaseExist
{
    public static void EnsureDatabaseExists(string connString)
    {
        var builder = new Npgsql.NpgsqlConnectionStringBuilder(connString);
        var databaseName = builder.Database;
        builder.Database = "postgres"; // Connect to the default DB to manage others

        using var conn = new Npgsql.NpgsqlConnection(builder.ConnectionString);
        conn.Open();

        using var cmd = conn.CreateCommand();
        cmd.CommandText = $"SELECT 1 FROM pg_database WHERE datname = '{databaseName}'";
        var exists = cmd.ExecuteScalar();

        if (exists == null)
        {
            using var createCmd = conn.CreateCommand();
            createCmd.CommandText = $"CREATE DATABASE \"{databaseName}\"";
            createCmd.ExecuteNonQuery();
        }
    }
}
