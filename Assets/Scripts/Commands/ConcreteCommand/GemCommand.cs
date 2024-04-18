using ChestSystem.Main;
using ChestSystem.Transaction;
using ChestSystem.Commands.Abstract;
using ChestSystem.Chest;
using ChestSystem.UI;

namespace ChestSystem.Commands.Concrete
{
    public class GemCommand : ChestCommand
    {
        private TransactionService TransactionService => GameService.Instance.TransactionService;
        private UIService UIService => GameService.Instance.UIService;

        private ChestController chestController;
        public GemCommand(ChestController chestController, int gemCount)
        {
            this.chestController = chestController;
            this.gemCount = gemCount;
        }
        public override void Execute() 
        { 
            TransactionService.DeductGems(gemCount);
            UIService.SwitchUndoBtn(true);
        }

        public override void Undo() 
        {
            TransactionService.AddCoinGemCount(gemCount);
            chestController.SetLockedState();
        } 
    }
}

