using ChestSystem.Main;
using ChestSystem.UI;

namespace ChestSystem.Transaction
{
    public class TransactionService
    {
       #region --------- Private Variables ---------
       private int currentGemCount;
       private int currentCoinCount;

       private UIService UIService => GameService.Instance.UIService;
       #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        
        #endregion ------------------

        #region --------- Public Methods ---------

        public TransactionService()
        {
            currentGemCount = 0;
            currentCoinCount = 0;
            UIService.SetGemCoinCount(currentGemCount,currentCoinCount);
        }

        public bool IsValidTransaction(int chestGem) => chestGem <= currentGemCount;


        #endregion ------------------


    }
}