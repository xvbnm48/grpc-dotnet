using Grpc.Core;
using GrpcService112.Configuration;
using GrpcService112.Services;
using GrpcService112.UseCase.@interface;
using Newtonsoft.Json;

namespace GrpcService112.UseCase
{
    public class TicketUseCase : ITicketUseCase
    {
        private readonly ILogger<ITicketUseCase> _logger;
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public TicketUseCase(ILogger<TicketUseCase> logger, IDbConnectionFactory dbConnectionFactory)
        {
            _logger = logger;
            _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
        }
        public async Task<bool> TestConnection()
        {
            try
            {
                using var connection = await _dbConnectionFactory.CreateConnection();
                connection.Open();
                _logger.LogInformation("connection success");
                return true;
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public async Task<resTicketMessage> Add(reqTicketCreate request, ServerCallContext context)
        {
            _logger.LogInformation("Add method called");
            _logger.LogInformation($"isi req {JsonConvert.SerializeObject(request)}");
            _logger.LogInformation($"Add method called");
            // test connection
            var connected = await TestConnection();
            //TestConnection();
            if (!connected)
            {
                _logger.LogError("error to connect mysql");
            }
            _logger.LogInformation("connection success");
            var result = new resTicketMessage();
            result.Message = "success";

            return result;
            //return await _ticketUseCase.Add(request, context);
            //throw new NotImplementedException();
        }
    }
}
