using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        #region --------- Serialized Variables ---------

        [SerializeField] private TextMeshProUGUI chestName;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI statusText;
        [SerializeField] private GameObject unlockingPanel;
        [SerializeField] private Image chestImage;
        [SerializeField] private Button chestButton;
        #endregion ------------------

        #region --------- Private Variables ---------

        private ChestController chestController;
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        #endregion ------------------

        #region --------- Private Methods ---------
        
        #endregion ------------------

        #region --------- Public Methods ---------
        
        public void SetController(ChestController chestController) => this.chestController = chestController;

        #endregion ------------------
    }
}