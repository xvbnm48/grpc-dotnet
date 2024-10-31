using MySql.Data.MySqlClient;
using System.Data;

namespace GrpcService112.Configuration.Mysql
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IDbConnection> CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("MySqlConnection");
            var connection = new MySqlConnection(connectionString);
            await Task.CompletedTask;
            return connection;
            //return new MySqlConnection(connectionString);
        }

        //public IDbConnection CreateConnection()
        //{
        //    var connectionString = _configuration.GetConnectionString("MySqlConnection");
        //    return new MySqlConnection(connectionString);
    
    }
}
