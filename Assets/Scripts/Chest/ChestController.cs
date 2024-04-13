using ChestSystem.Chest;
using ChestSystem.ScriptableObjects;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        #region --------- Private Variables ---------
        #endregion ------------------
        
        #region --------- Protected Variables ---------
        protected ChestView chestView;
        protected ChestModel chestModel;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------
        
        #region --------- Private Methods ---------

        private void InitializeModel(ChestScriptableObject chestScriptableObject)
        {
            chestModel = new ChestModel(chestScriptableObject);
            chestModel.SetController(this);
        }
        
        private void InitializeView(ChestView chestPrefab)
        {
            chestView = Object.Instantiate(chestPrefab);
            chestView.SetController(this);
        }
        #endregion ------------------

        #region --------- Public Methods ---------

        public void Init(ChestScriptableObject chestScriptableObject,ChestView chestPrefab)
        {
            InitializeModel(chestScriptableObject);
            InitializeView(chestPrefab);
        }
        #endregion ------------------
    }
}