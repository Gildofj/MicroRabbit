using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using MicroRabit.Domain.Core.Bus;

namespace MicroRabbit.Transfer.Domain.Events.Transfer
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;
        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                AccountFrom = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amount,
            });

            return Task.CompletedTask;
        }
    }
}
