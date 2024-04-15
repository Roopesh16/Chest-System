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
        [FormerlySerializedAs("OptionPanel")] [SerializeField] private GameObject optionPanel;
        [SerializeField] private TextMeshProUGUI timerBtnText;
        [SerializeField] private TextMeshProUGUI gemsBtnText;
        #endregion ------------------

        #region --------- Private Variables ---------

        private ChestController chestController;
        private int timer;
        private const float WaitTime = 1f;
        private const int HourSeconds = 3600;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        #endregion ------------------

        #region --------- Private Methods ---------

        private void SubscribeToEvents()
        {
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

        private void EnableOptionPanel()
        {
            if(optionPanel.activeSelf)
                return;
            optionPanel.SetActive(true);
        } 
        #endregion ------------------

        #region --------- Public Methods ---------
        
        public void SetController(ChestController chestController) => this.chestController = chestController;
        
        public void SetupChestSlots(string chestName, Sprite chestSprite,int timer)
        {
            SubscribeToEvents();
            chestText.text = chestName;
            chestImage.sprite = chestSprite;
            this.timer = timer;

            TimeSpan ts = TimeSpan.FromSeconds(timer);
            if (timer >= HourSeconds)
            {
                timerBtnText.text = ts.Hours + (ts.Hours == 1 ? " Hr" : " Hrs");
            }
            else
            {
                timerBtnText.text = ts.Minutes + (ts.Minutes == 1 ? " Min" : " Mins");
            }
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