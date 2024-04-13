using ChestSystem.Chest;
using ChestSystem.UI;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        #region --------- Serialized Variables ---------
        [SerializeField] private UIService uiService;
        #endregion ------------------
        
        #region --------- Public Variables ---------
        public ChestService ChestService { get; private set; }
        public UIService UIService => uiService;
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        protected override void Awake()
        {
            base.Awake();
            ChestService = new ChestService();
        }
        #endregion ------------------
    }
}