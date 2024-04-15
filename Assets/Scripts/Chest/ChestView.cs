using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        #region --------- Serialized Variables ---------

        [FormerlySerializedAs("chestName")] [SerializeField] private TextMeshProUGUI chestText;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI statusText;
        [SerializeField] private GameObject unlockingPanel;
        [SerializeField] private Image chestImage;
        [SerializeField] private Button chestButton;
        #endregion ------------------

        #region --------- Private Variables ---------

        private ChestController chestController;
        private int timer;
        private const float WaitTime = 1f;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        #endregion ------------------

        #region --------- Private Methods ---------

        private void SubscribeToEvents()
        {
            chestButton.onClick.AddListener(chestController.ShakeChestSprite);
            chestButton.onClick.AddListener(EnableOptionPanel);
        }

        private IEnumerator StartTimer()
        {
            while (--timer >= 0)
            {
                chestController.SetTimerText(timer);
                yield return new WaitForSecondsRealtime(WaitTime);
            }
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        
        public void SetController(ChestController chestController) => this.chestController = chestController;

        public void SetupChestSlots(string chestName, Sprite chestSprite,int timer)
        {
            chestButton.onClick.AddListener(chestController.ShakeChestSprite);
            chestText.text = chestName;
            chestImage.sprite = chestSprite;
            this.timer = timer;
        }

        public Image GetChestImage() => chestImage;

        public void SetChestOpen(Sprite openChestSprite)
        {
            chestImage.sprite = openChestSprite;
            unlockingPanel.SetActive(true);
            statusText.gameObject.SetActive(false);
            StartCoroutine(StartTimer());
        }

        public void SetUnlockTimer(string time) => timerText.text = time;

        #endregion ------------------
    }
}