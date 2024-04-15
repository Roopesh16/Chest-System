using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ChestSystem.Main;
using ChestSystem.Chest;
using ChestSystem.Input;
using System.Collections;

namespace ChestSystem.UI
{
    public class UIService : MonoBehaviour
    {
        #region --------- Serialized Variables ---------

        [SerializeField] private Button generateButton;
        [SerializeField] private Transform chestSlots;
        [SerializeField] private TextMeshProUGUI gemText;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private GameObject invalidPanel;
        #endregion ------------------

        #region --------- Private Variables ---------

        private ChestService ChestService => GameService.Instance.ChestService;
        private InputService InputService => GameService.Instance.InputService;

        private int childIndex = 0;
        private int siblingIndex = 1;

        #endregion ------------------

        #region --------- Public Variables ---------

        #endregion ------------------

        #region --------- Monobehavior Methods ---------

        private void Awake()
        {
            generateButton.onClick.AddListener(OnGenerateClick);
        }

        private IEnumerator InvalidPanelTimer()
        {
            invalidPanel.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            invalidPanel.SetActive(false);
        }

        #endregion ------------------

        #region --------- Private Methods ---------

        private void OnGenerateClick()
        {
            if (!InputService.CanSpawnChest()) return;
            
            InputService.IncrementOpenChest();
            chestSlots.GetChild(childIndex).gameObject.SetActive(false);
            ChestService.SpawnRandomChest(chestSlots,siblingIndex);
            IncrementIndices();
        }

        private void IncrementIndices()
        {
            childIndex += 2;
            siblingIndex += 2;
        }

        public void SetGemCoinCount(int gemCount, int coinCount)
        {
            gemText.text = gemCount.ToString();
            coinText.text = coinCount.ToString();
        }

        public void DisplayInvalidText()
        {
            StartCoroutine(InvalidPanelTimer());
        }
        #endregion ------------------

        #region --------- Public Methods ---------

        #endregion ------------------

    }
}