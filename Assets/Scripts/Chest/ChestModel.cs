using ChestSystem.ScriptableObjects;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestModel
    {
        #region --------- Private Variables ---------
        public ChestTypes ChestTypes;
        public int MinCoinCount;
        public int MaxCoinCount;
        public int MinGemCount;
        public int MaxGemCount;
        public Sprite ClosedChestSprite;
        public Sprite OpenChestSprite;
        public float TimerMins;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------
        
        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------

        public ChestModel(ChestScriptableObject chestScriptableObject)
        {
            this.ChestTypes = chestScriptableObject.ChestTypes;
            this.MinCoinCount = chestScriptableObject.MinCoinCount;
            this.MaxCoinCount = chestScriptableObject.MaxCoinCount;
            this.MinGemCount = chestScriptableObject.MinGemCount;
            this.MaxGemCount = chestScriptableObject.MaxGemCount;
            this.ClosedChestSprite = chestScriptableObject.ClosedChestSprite;
            this.OpenChestSprite = chestScriptableObject.OpenChestSprite;
            this.TimerMins = chestScriptableObject.TimerMins;
        }
        #endregion ------------------
    }
}