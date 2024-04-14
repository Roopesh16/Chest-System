using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Input
{
    public class InputService
    {
        #region --------- Private Variables ---------

        public int TotalSlots { get; private set; } = 4;
        private int currentOpenSlots = 0;

        #endregion ------------------

        #region --------- Public Variables ---------

        #endregion ------------------

        #region --------- Private Methods ---------

        #endregion ------------------

        #region --------- Public Methods ---------

        public bool CanSpawnChest() => currentOpenSlots <= TotalSlots;

        public void IncrementOpenChest() => currentOpenSlots++;

        #endregion ------------------
    }
}

