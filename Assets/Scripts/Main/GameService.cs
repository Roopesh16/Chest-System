using System.Collections.Generic;
using ChestSystem.Chest;
using ChestSystem.UI;
using ChestSystem.Utilities;
using ChestSystem.ScriptableObjects;
using UnityEngine;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        #region --------- Serialized Variables ---------
        [Header("UI Reference")]
        [SerializeField] private UIService uiService;

        [Header("Chest References")] 
        [SerializeField] private ChestView chestPrefab;
        [SerializeField] private List<ChestScriptableObject> chestsList = new();
        
        #endregion ------------------
        
        #region --------- Public Variables ---------
        public ChestService ChestService { get; private set; }
        public UIService UIService => uiService;
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        protected override void Awake()
        {
            base.Awake();
            ChestService = new ChestService(chestsList,chestPrefab);
        }
        #endregion ------------------
    }
}