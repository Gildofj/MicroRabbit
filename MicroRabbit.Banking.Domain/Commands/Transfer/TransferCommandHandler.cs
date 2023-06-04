using MediatR;
using MicroRabbit.Banking.Domain.Events.Transfer;
using MicroRabit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Domain.Commands.Transfer
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));

            return Task.FromResult(true);
        }
    }
}
