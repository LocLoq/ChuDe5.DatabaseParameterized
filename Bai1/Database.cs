using Microsoft.Data.SqlClient;
using System.Data;

namespace Bai1;

internal static class Database
{
    private static SqlParameter[] MakeParameters(Dictionary<string, object> values, List<SqlDbType> types)
    {
        if (values.Count != types.Count)
            throw new ArgumentException("Số lượng giá trị và kiểu tham số phải bằng nhau.");
        return values.Zip(types, (pair, type) => new SqlParameter(pair.Key, type)
        { Value = pair.Value ?? DBNull.Value }).ToArray();
    }

    internal static SqlDataReader ExecuteQuery(string query) => ExecuteQuery(query, CommandType.Text);
    internal static SqlDataReader ExecuteQuery(string query, Dictionary<string, object> values, List<SqlDbType> types)
        => ExecuteQuery(query, CommandType.Text, MakeParameters(values, types));

    internal static SqlDataReader ExecuteQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
    {
        var connection = new SqlConnection(Program.ConnectionString);
        var command = new SqlCommand(commandText, connection) { CommandType = commandType };
        try
        {
            foreach (var parameter in parameters)
            {
                if (parameter.Direction is ParameterDirection.Input or ParameterDirection.InputOutput)
                    parameter.Value ??= DBNull.Value;
                command.Parameters.Add(parameter);
            }
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            command.Dispose();
            return reader;
        }
        catch
        {
            command.Dispose();
            connection.Dispose();
            throw;
        }
    }

    internal static int ExecuteNonQuery(string statement) => ExecuteNonQuery(statement, CommandType.Text);
    internal static int ExecuteNonQuery(string statement, Dictionary<string, object> values, List<SqlDbType> types)
        => ExecuteNonQuery(statement, CommandType.Text, MakeParameters(values, types));
    internal static int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
    {
        using var connection = new SqlConnection(Program.ConnectionString);
        connection.Open();
        return ExecuteNonQuery(commandText, commandType, connection, null, parameters);
    }

    internal static int ExecuteNonQuery(string commandText, CommandType commandType, SqlConnection connection,
        SqlTransaction? transaction, params SqlParameter[] parameters)
    {
        using var command = new SqlCommand(commandText, connection, transaction) { CommandType = commandType };
        foreach (var parameter in parameters)
        {
            if (parameter.Direction is ParameterDirection.Input or ParameterDirection.InputOutput)
                parameter.Value ??= DBNull.Value;
            command.Parameters.Add(parameter);
        }
        return command.ExecuteNonQuery();
    }

    internal static SqlParameter Param(string name, SqlDbType type, object? value, int size = 0)
        => new(name, type) { Size = size, Value = value ?? DBNull.Value };

    internal static DataTable ReadTable(string procedure, params SqlParameter[] parameters)
    {
        using var reader = ExecuteQuery(procedure, CommandType.StoredProcedure, parameters);
        var table = new DataTable();
        table.Load(reader);
        return table;
    }
}

