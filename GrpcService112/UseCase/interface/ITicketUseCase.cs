using Grpc.Core;

namespace GrpcService112.UseCase.@interface
{
    public interface ITicketUseCase
    {
        Task<resTicketMessage> Add(reqTicketCreate request, ServerCallContext context);
    }
}
