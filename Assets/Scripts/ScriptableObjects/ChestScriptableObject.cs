using ChestSystem.Chest;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChestSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChestScriptableObject", menuName = "ChestScriptableObjects")]
    public class ChestScriptableObject : ScriptableObject
    {
        public ChestTypes ChestTypes;
        public string ChestName;
        public int MinCoinCount;
        public int MaxCoinCount;
        public int MinGemCount;
        public int MaxGemCount;
        public Sprite ClosedChestSprite;
        public Sprite OpenChestSprite;
        [Range(0.1f, 1f)] public float shakeDuration;
        [Range(0.1f, 0.5f)] public float shakeStrength;
        [FormerlySerializedAs("timerMins")] public float TimerMins;
    }
}