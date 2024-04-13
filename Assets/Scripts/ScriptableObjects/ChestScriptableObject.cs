using ChestSystem.Chest;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChestSystem.ScriptableObjects
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
        [FormerlySerializedAs("timerMins")] public float TimerMins;
    }
}