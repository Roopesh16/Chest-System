using UnityEngine;
using ChestSystem.UI;
using ChestSystem.Input;
using ChestSystem.Chest;
using ChestSystem.Utilities;
using ChestSystem.Transaction;
using System.Collections.Generic;
using ChestSystem.ScriptableObjects;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        //  Private Variables
        [Header("UI Reference")]
        [SerializeField] private UIService uiService;

        [Header("Chest References")] 
        [SerializeField] private ChestView chestPrefab;
        [SerializeField] private List<ChestScriptableObject> chestsList = new();
        
        // Public Variables 
        public ChestService ChestService { get; private set; }
        public InputService InputService { get; private set; }
        public TransactionService TransactionService { get; private set; }
        public CommandInvoker CommandInvoker { get; private set; }
        public UIService UIService => uiService;

        //  Monobehavior Methods
        protected override void Awake()
        {
            base.Awake();
            ChestService = new ChestService(chestsList,chestPrefab);
            InputService = new InputService();
            TransactionService = new TransactionService();
            CommandInvoker = new CommandInvoker();
        }
    }
}