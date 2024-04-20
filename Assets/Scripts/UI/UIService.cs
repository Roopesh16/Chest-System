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
        // Private Variables
        [SerializeField] private Button generateButton;
        [SerializeField] private Button undoButton;
        [SerializeField] private Transform chestSlots;
        [SerializeField] private TextMeshProUGUI gemText;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private GameObject invalidPanel;
        [SerializeField] private List<GameObject> emptySlotList = new();

        private ChestService ChestService => GameService.Instance.ChestService;
        private InputService InputService => GameService.Instance.InputService;
        private CommandInvoker CommandInvoker => GameService.Instance.CommandInvoker;

        private int childIndex = 0;
        private int siblingIndex = 1;

        // Monobehavior Methods

        private void Awake()
        {
            generateButton.onClick.AddListener(OnGenerateClick);
            undoButton.onClick.AddListener(OnUndoClick);
        }

        private void Start() => SwitchUndoBtn(false);

        // Private Methods
        private IEnumerator InvalidPanelTimer()
        {
            invalidPanel.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            invalidPanel.SetActive(false);
        }

        private void OnGenerateClick()
        {
            if (!InputService.CanSpawnChest()) return;

            chestSlots.GetChild(childIndex).gameObject.SetActive(false);
            InputService.IncrementOpenChest();
            ChestService.SpawnRandomChest(chestSlots, siblingIndex);
            IncrementIndices();
        }

        private void OnUndoClick()
        {
            CommandInvoker.UndoCommand();
            SwitchUndoBtn(false);
        }

        private void IncrementIndices()
        {
            childIndex += 2;
            siblingIndex += 2;
        }

        //  Public Methods
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

            if (index != 0 && !emptySlotList[index - 1].activeSelf)
                childIndex = InputService.GetEmptySlot() + 1;
            else
                childIndex = InputService.GetEmptySlot();

            siblingIndex = childIndex + 1;
        }

        public bool IsSlotAvailable(int index) => emptySlotList[index].activeSelf;

        public void SwitchUndoBtn(bool isActive) => undoButton.gameObject.SetActive(isActive);
    }
}