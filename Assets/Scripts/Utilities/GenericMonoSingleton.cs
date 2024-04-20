using UnityEngine;

namespace ChestSystem.Utilities
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        // Private Variables
        private static T instance = null;

        //  Public Variables
        public static T Instance
        {
            get { return instance; }
        }

        // Monobehavior Methods
        protected virtual void Awake()
        {
            if (instance == null)
                instance = (T)this;
            else
            {
                Destroy(this);
            }
        }
    }    
}

