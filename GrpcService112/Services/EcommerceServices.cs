using Grpc.Core;
using GrpcService112;
using GrpcService112.UseCase.@interface;

namespace GrpcService112.Services
{
    public class EcommerceServices : ecommerce.ecommerceBase
    {
        private readonly ILogger<EcommerceServices> _logger;
        private readonly ITicketUseCase _ticketUseCase;
        public EcommerceServices(ILogger<EcommerceServices> logger, ITicketUseCase ticketUseCase)
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
