using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ChestSystem.Main;
using ChestSystem.Chest;
using ChestSystem.Input;
using System.Collections;
using System.Collections.Generic;

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
        [SerializeField] private List<GameObject> emptySlotList = new();
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
            
            chestSlots.GetChild(childIndex).gameObject.SetActive(false);
            InputService.IncrementOpenChest();
            ChestService.SpawnRandomChest(chestSlots,siblingIndex);
            IncrementIndices();
        }

        private void IncrementIndices()
        {
            childIndex += 2;
            siblingIndex += 2;
        }


        #endregion ------------------

        #region --------- Public Methods ---------
        public void SetGemCoinCount(int gemCount, int coinCount)
        {
            gemText.text = gemCount.ToString();
            coinText.text = coinCount.ToString();
        }

        public void DisplayInvalidText() => StartCoroutine(InvalidPanelTimer());
        public void EnableEmptySlot(int index) 
        {
            emptySlotList[index].SetActive(true);
            InputService.SetEmptySlot(index);

            if(index!=0 && !emptySlotList[index-1].activeSelf)
                childIndex = InputService.GetEmptySlot() + 1;
            else
                childIndex = InputService.GetEmptySlot();

            siblingIndex = childIndex + 1;
        } 

        public bool IsSlotAvailable(int index) => emptySlotList[index].activeSelf;

        #endregion ------------------

    }
}