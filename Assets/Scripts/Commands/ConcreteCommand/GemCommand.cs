using ChestSystem.Main;
using ChestSystem.Transaction;
using ChestSystem.Commands.Abstract;

namespace ChestSystem.Commands.Concrete
{
    public class GemCommand : ChestCommand
    {
        private TransactionService TransactionService => GameService.Instance.TransactionService;

        public GemCommand(int gemCount) => this.gemCount = gemCount;

        public override void Execute() =>  TransactionService.DeductGems(gemCount);

        public override void Undo() => TransactionService.AddCoinGemCount(gemCount);
    }
}

