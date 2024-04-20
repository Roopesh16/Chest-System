using System.Collections.Generic;
using ChestSystem.Input;
using ChestSystem.Main;
using ChestSystem.ScriptableObjects;
using ChestSystem.UI;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestService
    {
       // Private Variables
        private List<ChestScriptableObject> chestsList = new();
        private List<ChestController> spawnedChests = new();
        private ChestView chestPrefab;

        private UIService UIService => GameService.Instance.UIService;
        private InputService InputService => GameService.Instance.InputService;


        // Constructor

        public ChestService(List<ChestScriptableObject> chestsList,ChestView chestPrefab)
        {
            this.chestsList = chestsList;
            this.chestPrefab = chestPrefab;
        }

        // Public Methods

        public void SpawnRandomChest(Transform parent,int siblingIndex)
        {
            int index = Random.Range(0, chestsList.Count);
            ChestController spawnChest = new ChestController(chestsList[index],chestPrefab,parent,siblingIndex,spawnedChests.Count);
            spawnedChests.Add(spawnChest);
        }

        public void RemoveChestSlot(ChestController chestController,int index)
        {
            spawnedChests.Remove(chestController); 
            UIService.EnableEmptySlot(index);
        }
    }
}