using Grpc.Core;
using GrpcService112;
using GrpcService112.UseCase.@interface;

namespace GrpcService112.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly ITicketUseCase _ticketUseCase;
        public GreeterService(ILogger<GreeterService> logger, ITicketUseCase ticketUseCase)
        {
            _logger = logger;
            _ticketUseCase = ticketUseCase;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
        public override async Task<resTicketMessage> Add(reqTicketCreate request, ServerCallContext context)
        {
            return await _ticketUseCase.Add(request, context);
        }
    }
}
