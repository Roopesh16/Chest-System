using System.Collections.Generic;
using ChestSystem.Chest.Chests;
using ChestSystem.ScriptableObjects;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestService
    {
        #region --------- Private Variables ---------
        private List<ChestScriptableObject> chestsList = new();
        private Dictionary<ChestTypes, ChestController> chestDict = new();
        private ChestView chestPrefab;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------
        
        #region --------- Private Methods ---------

        private void CreateChestControllers()
        {
            chestDict.Add(ChestTypes.COMMON,new CommonChestController());
            chestDict.Add(ChestTypes.RARE,new RareChestController());
            chestDict.Add(ChestTypes.EPIC,new EpicChestController());
            chestDict.Add(ChestTypes.LEGENDARY,new LegendaryChestController());
        }
        #endregion ------------------

        #region --------- Public Methods ---------

        public ChestService(List<ChestScriptableObject> chestsList,ChestView chestPrefab)
        {
            CreateChestControllers();
            this.chestsList = chestsList;
            this.chestPrefab = chestPrefab;
        }

        public void SpawnRandomChest(Transform parent,int siblingIndex)
        {
            int index = Random.Range(0, chestsList.Count);
            ChestController spawnChest = chestDict[chestsList[index].ChestTypes];
            spawnChest.Init(chestsList[index],chestPrefab,parent,siblingIndex);
        }
        #endregion ------------------
    }
}