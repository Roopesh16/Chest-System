using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        #region --------- Serialized Variables ---------

        [FormerlySerializedAs("chestName")] [SerializeField] private TextMeshProUGUI chestText;
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

        public void SetupChestSlots(string chestName, Sprite chestSprite)
        {
            chestButton.onClick.AddListener(chestController.ShakeChestSprite);
            chestText.text = chestName;
            chestImage.sprite = chestSprite;
        }

        public Image GetChestImage() => chestImage;

        #endregion ------------------
    }
}