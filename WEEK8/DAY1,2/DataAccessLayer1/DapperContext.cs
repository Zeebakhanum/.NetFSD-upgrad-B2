
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class DapperContext
{
    private readonly IConfiguration _config;

    public DapperContext(IConfiguration config)
    {
        _config = config;
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    }
}