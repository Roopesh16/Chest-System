using System;
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

        private void InitializeModel(ChestScriptableObject chestScriptableObject)
        {
            chestModel = new ChestModel(chestScriptableObject);
            chestModel.SetController(this);
        }
        
        private void InitializeView(ChestView chestPrefab, Transform parent,int siblingIndex)
        {
            chestView = GameObject.Instantiate(chestPrefab,parent);
            chestView.SetController(this);
            chestView.SetupChestSlots(chestModel.ChestName,chestModel.ClosedChestSprite);
            chestView.transform.SetSiblingIndex(siblingIndex);
        }

        private void SetOpenImage()
        {
            chestView.SetOpenChestImage(chestModel.OpenChestSprite);
            TimeSpan timeSpan = TimeSpan.FromSeconds(chestModel.TimerSecs);
            string time = string.Format("{0:D2}:{1:D2}:{2:D2}",timeSpan.Hours,timeSpan.Minutes,timeSpan.Seconds);
            chestView.SetUnlockTimer(time);
        }
        #endregion ------------------
        
        #region --------- Protected Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------

        public ChestController(ChestScriptableObject chestScriptableObject,ChestView chestPrefab,Transform parent,int siblingIndex)
        {
            InitializeModel(chestScriptableObject);
            InitializeView(chestPrefab,parent,siblingIndex);
        }
        
        public void ShakeChestSprite()
        {
            Transform imgTransform = chestView.GetChestImage().transform;
            imgTransform.DOShakePosition(chestModel.ShakeDuration,chestModel.ShakeStrength);
            imgTransform.DOShakeScale(chestModel.ShakeDuration, chestModel.ShakeStrength);

            SetOpenImage();
        }
        #endregion ------------------
    }
}