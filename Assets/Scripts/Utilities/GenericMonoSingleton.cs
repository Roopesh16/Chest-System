using UnityEngine;

namespace ChestSystem.Utilities
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        #region --------- Private Variables ---------
        private static T instance = null;
        #endregion ------------------

        #region --------- Public Variables ---------
        public static T Instance
        {
            get { return instance; }
        }
        #endregion ------------------

        #region --------- Monobehavior Methods ---------
        protected virtual void Awake()
        {
            if (instance == null)
                instance = (T)this;
            else
            {
                Destroy(this);
            }
        }

        #endregion ------------------
    }    
}

