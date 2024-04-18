using System;
using DG.Tweening;
using UnityEngine;
using ChestSystem.UI;
using ChestSystem.Main;
using ChestSystem.Transaction;
using ChestSystem.Chest.States;
using Random = UnityEngine.Random;
using ChestSystem.ScriptableObjects;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        #region --------- Private Variables ---------

        private TransactionService TransactionService => GameService.Instance.TransactionService;
        private UIService UIService => GameService.Instance.UIService;
        private ChestService ChestService => GameService.Instance.ChestService;

        private const int HourSeconds = 3600;
        private int gemCount;
        private int index;

        private ChestStateMachine stateMachine;
        #endregion ------------------

        #region --------- Protected Variables ---------
        protected ChestView chestView;
        protected ChestModel chestModel;
        #endregion ------------------

        #region --------- Public Variables ---------
        public ChestView View => chestView;
        public ChestModel Model => chestModel;
        #endregion ------------------

        #region --------- Private Methods ---------

        private void CreateStateMachine() => stateMachine = new ChestStateMachine(this);

        private void InitializeModel(ChestScriptableObject chestScriptableObject)
        {
            chestModel = new ChestModel(chestScriptableObject);
            chestModel.SetController(this);
        }

        private void InitializeView(ChestView chestPrefab, Transform parent, int siblingIndex)
        {
            chestView = GameObject.Instantiate(chestPrefab, parent);
            chestView.SetController(this);
            chestView.SetupChestSlots(chestModel.ChestName, chestModel.ClosedChestSprite, chestModel.TimerSecs,
                GetTimerBtnText(chestModel.TimerSecs), GetGemBtnText(chestModel.TimerSecs));
            chestView.transform.SetSiblingIndex(siblingIndex);
        }

        private string GetGemBtnText(int timer)
        {
            TimeSpan ts = TimeSpan.FromSeconds(timer);
            gemCount = Mathf.CeilToInt((ts.Hours * 60 + ts.Minutes) * 0.1f);
            return gemCount.ToString();
        }

        private string GetTimerBtnText(int timer)
        {
            string text;
            TimeSpan ts = TimeSpan.FromSeconds(timer);
            if (timer >= HourSeconds)
            {
                text = ts.Hours + (ts.Hours == 1 ? " Hr" : " Hrs");
            }
            else
            {
                text = ts.Minutes + (ts.Minutes == 1 ? " Min" : " Mins");
            }

            return text;
        }
        #endregion ------------------

        #region --------- Public Methods ---------

        public ChestController(ChestScriptableObject chestScriptableObject, ChestView chestPrefab, Transform parent, int siblingIndex, int index)
        {
            this.index = index;
            CreateStateMachine();
            InitializeModel(chestScriptableObject);
            InitializeView(chestPrefab, parent, siblingIndex);
            stateMachine.ChangeState(ChestStates.LOCKED);
        }

        public void ShakeChestSprite()
        {
            Transform imgTransform = chestView.GetChestImage().transform;
            imgTransform.DOShakePosition(chestModel.ShakeDuration, chestModel.ShakeStrength);
            imgTransform.DOShakeScale(chestModel.ShakeDuration, chestModel.ShakeStrength);
        }

        public void OpenChestByGems()
        {
            if (TransactionService.IsValidTransaction(gemCount))
            {
                TransactionService.DeductGems(gemCount);
                SetUnlockedState();
            }
            else
                UIService.DisplayInvalidText();
        }

        public void OnChestComplete()
        {
            int randGem = Random.Range(chestModel.MinGemCount, chestModel.MaxGemCount);
            int randCoin = Random.Range(chestModel.MinCoinCount, chestModel.MaxCoinCount);

            ChestService.RemoveChestSlot(this, index);
            TransactionService.AddCoinGemCount(randGem, randCoin);
            GameObject.Destroy(chestView.gameObject);
        }

        public void SetTimerText(int timer)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
            string time = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
            chestView.SetUnlockTimer(time);
        }

        public void SetUnlockingState() => stateMachine.ChangeState(ChestStates.UNLOCKING);

        public void SetUnlockedState() => stateMachine.ChangeState(ChestStates.UNLOCKED);
        #endregion ------------------
    }
}