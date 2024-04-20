using UnityEngine;
using ChestSystem.ScriptableObjects;

namespace ChestSystem.Chest
{
    public class ChestModel
    {
        // Private Variables
        private ChestController chestController;

        // Public Variables
        public ChestTypes ChestTypes { get; private set; }
        public string ChestName { get; private set; }
        public int MinCoinCount { get; private set; }
        public int MaxCoinCount { get; private set; }
        public int MinGemCount { get; private set; }
        public int MaxGemCount { get; private set; }
        public Sprite ClosedChestSprite { get; private set; }
        public Sprite OpenChestSprite { get; private set; }
        public float ShakeDuration { get; private set; }
        public float ShakeStrength { get; private set; }
        public int TimerSecs { get; private set; }

        // Public Methods

        public ChestModel(ChestScriptableObject chestScriptableObject)
        {
            this.ChestTypes = chestScriptableObject.ChestTypes;
            this.ChestName = chestScriptableObject.ChestName;
            this.MinCoinCount = chestScriptableObject.MinCoinCount;
            this.MaxCoinCount = chestScriptableObject.MaxCoinCount;
            this.MinGemCount = chestScriptableObject.MinGemCount;
            this.MaxGemCount = chestScriptableObject.MaxGemCount;
            this.ClosedChestSprite = chestScriptableObject.ClosedChestSprite;
            this.OpenChestSprite = chestScriptableObject.OpenChestSprite;
            this.ShakeDuration = chestScriptableObject.shakeDuration;
            this.ShakeStrength = chestScriptableObject.shakeStrength;
            this.TimerSecs = chestScriptableObject.TimerSecs;
        }

        public void SetController(ChestController chestController) => this.chestController = chestController;
    }
}