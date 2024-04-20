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
       // Private Variables
        [FormerlySerializedAs("chestName")][SerializeField] private TextMeshProUGUI chestText;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI statusText;
        [SerializeField] private GameObject unlockingPanel;
        [SerializeField] private Image chestImage;
        [SerializeField] private Button chestButton;

        [Header("Option Panel")]
        [SerializeField] private GameObject optionPanel;
        [SerializeField] private TextMeshProUGUI timerBtnText;
        [SerializeField] private TextMeshProUGUI gemsBtnText;
        [SerializeField] private Button timerButton;
        [SerializeField] private Button gemsButton;
        
        private ChestController chestController;
        private int timer;
        private const float WaitTime = 1f;


        // Private Methods
        private void SubscribeToEvents()
        {
            chestButton.onClick.RemoveAllListeners();
            timerButton.onClick.RemoveAllListeners();
            gemsButton.onClick.RemoveAllListeners();

            chestButton.onClick.AddListener(chestController.ShakeChestSprite);
            chestButton.onClick.AddListener(EnableOptionPanel);

            timerButton.onClick.AddListener(chestController.SetUnlockingState);
            gemsButton.onClick.AddListener(chestController.OpenChestByGems);

            timerButton.onClick.AddListener(DisableOptionPanel);
            gemsButton.onClick.AddListener(DisableOptionPanel);
        }

        private IEnumerator StartTimer()
        {
            while (--timer >= 0)
            {
                chestController.SetTimerText(timer);
                yield return new WaitForSecondsRealtime(WaitTime);
            }

            chestController.SetUnlockedState();
        }

        private void EnableOptionPanel()
        {
            if (optionPanel.activeSelf)
                return;
            optionPanel.SetActive(true);
        }

        private void DisableOptionPanel() => optionPanel.SetActive(false);

        // Public Methods
        public void SetController(ChestController chestController) => this.chestController = chestController;

        public void SetupChestSlots(string chestName, Sprite chestSprite, int timer, string timerText, string gemText)
        {
            SubscribeToEvents();
            chestText.text = chestName;
            chestImage.sprite = chestSprite;
            this.timer = timer;
            timerBtnText.text = timerText;
            gemsBtnText.text = gemText;
        }

        public Image GetChestImage() => chestImage;

        public void StartChestUnlocking()
        {
            unlockingPanel.SetActive(true);
            statusText.gameObject.SetActive(false);
            StartCoroutine(StartTimer());
        }

        public void SetUnlockTimer(string time) => timerText.text = time;

        public void OnChestUnlocked(string completedString, Sprite unlockedSprite)
        {
            unlockingPanel.SetActive(false);
            statusText.gameObject.SetActive(true);
            statusText.text = completedString;
            chestImage.sprite = unlockedSprite;
            chestButton.onClick.RemoveAllListeners();
            chestButton.onClick.AddListener(chestController.OnChestComplete);
        }
    }
}