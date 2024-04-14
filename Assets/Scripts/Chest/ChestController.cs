using UnityEngine;
using ChestSystem.ScriptableObjects;
using DG.Tweening;

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
        
        private void InitializeView(ChestView chestPrefab, Transform parent,int siblingIndex)
        {
            chestView = Object.Instantiate(chestPrefab,parent);
            chestView.SetupChestSlots(chestModel.ChestName,chestModel.ClosedChestSprite);
            chestView.transform.SetSiblingIndex(siblingIndex);
        }
        #endregion ------------------

        #region --------- Public Methods ---------

        public void Init(ChestScriptableObject chestScriptableObject,ChestView chestPrefab,Transform parent,int siblingIndex)
        {
            chestModel = new ChestModel(chestScriptableObject);
            InitializeView(chestPrefab,parent,siblingIndex);
        }

        public void ShakeChestSprite()
        {
            Transform imgTransform = chestView.GetChestImage().transform;
            imgTransform.DOShakePosition(chestModel.ShakeDuration,chestModel.ShakeStrength);
            imgTransform.DOShakeScale(chestModel.ShakeDuration, chestModel.ShakeStrength);
        }
            
        #endregion ------------------
    }
}