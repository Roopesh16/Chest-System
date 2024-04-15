using System.Collections.Generic;
using ChestSystem.ScriptableObjects;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestService
    {
        #region --------- Private Variables ---------
        private List<ChestScriptableObject> chestsList = new();
        private List<ChestController> spawnedChests = new();
        private ChestView chestPrefab;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------
        
        #region --------- Private Methods ---------
        #endregion ------------------

        #region --------- Public Methods ---------

        public ChestService(List<ChestScriptableObject> chestsList,ChestView chestPrefab)
        {
            this.chestsList = chestsList;
            this.chestPrefab = chestPrefab;
        }

        public void SpawnRandomChest(Transform parent,int siblingIndex)
        {
            int index = Random.Range(0, chestsList.Count);
            ChestController spawnChest = new ChestController(chestsList[index],chestPrefab,parent,siblingIndex);
            spawnedChests.Add(spawnChest);
        }
        #endregion ------------------
    }
}