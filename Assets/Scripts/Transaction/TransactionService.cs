using ChestSystem.Main;
using ChestSystem.UI;
using Unity.VisualScripting;

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

        public void DeductGems(int gemCount)
        {
            if (currentGemCount <= 0)
            {
                currentGemCount = 0;
                return;
            }
            
            currentGemCount -= gemCount;
            UIService.SetGemCoinCount(currentGemCount,currentCoinCount);
        }

        public void AddCoinGemCount(int gemCount, int coinCount)
        {
            currentGemCount += gemCount;
            currentCoinCount += coinCount;
            UIService.SetGemCoinCount(currentGemCount,currentCoinCount);
        }
        #endregion ------------------


    }
}