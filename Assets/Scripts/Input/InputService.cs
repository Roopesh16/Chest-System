using System.Collections;
using System.Collections.Generic;
using ChestSystem.Main;
using ChestSystem.UI;
using UnityEngine;

namespace ChestSystem.Input
{
    public class InputService
    {
        // Public Variable
        public int TotalSlots { get; private set; } = 4;
        
        // Private Variables 
        private int currentOpenSlots = 0;
        private int currentEmptySlot = 0;

        private UIService UIService => GameService.Instance.UIService;


        // Public Methods

        public bool CanSpawnChest() => currentOpenSlots < TotalSlots;

        public void IncrementOpenChest() 
        {
            currentOpenSlots++;

            while(currentEmptySlot < TotalSlots && !UIService.IsSlotAvailable(currentEmptySlot))
            {
                currentEmptySlot++;
            }
        }

        public void SetEmptySlot(int index)
        {
            currentOpenSlots--;

            if(index <= currentEmptySlot)
            {
                currentEmptySlot = index;
            }
        }

        public int GetEmptySlot() => currentEmptySlot;
    }
}

