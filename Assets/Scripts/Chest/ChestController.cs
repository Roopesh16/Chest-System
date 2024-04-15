using System;
using DG.Tweening;
using UnityEngine;
using ChestSystem.ScriptableObjects;

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
            chestView.SetupChestSlots(chestModel.ChestName,chestModel.ClosedChestSprite,chestModel.TimerSecs);
            chestView.transform.SetSiblingIndex(siblingIndex);
        }

        private void SetOpenImage() => chestView.SetChestOpen(chestModel.OpenChestSprite);

        public void SetTimerText(int timer)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
            string time = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
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

            // SetOpenImage();  -> Change this through events
        }
        #endregion ------------------
    }
}