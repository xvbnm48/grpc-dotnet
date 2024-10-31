using System.Data;

namespace GrpcService112.Configuration
{
    public interface IDbConnectionFactory
    {
        public Task<IDbConnection> CreateConnection();
    }
}
