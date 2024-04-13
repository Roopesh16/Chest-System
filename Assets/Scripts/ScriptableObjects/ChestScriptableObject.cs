using ChestSystem.Chest;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChestScriptableObject", menuName = "ChestScriptableObjects")]
    public class ChestScriptableObject : ScriptableObject
    {
        public ChestTypes ChestTypes;
        public int MinCoinCount;
        public int MaxCoinCount;
        public int MinGemCount;
        public int MaxGemCount;
        public Sprite ClosedChestSprite;
        public Sprite OpenChestSprite;
        public float timerMins;
    }
}