using Grpc.Core;
using GrpcService112;

namespace GrpcService112.UseCase
{
    public interface ITicketUseCase
    {
        Task<resTicketMessage> Add(reqTicketCreate request, ServerCallContext context);
    }
}
