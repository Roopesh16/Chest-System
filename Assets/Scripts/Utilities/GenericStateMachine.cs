using ChestSystem.Chest;
using ChestSystem.Chest.States;
using System.Collections.Generic;

namespace ChestSystem.Utilities
{
    public class GenericStateMachine<T> where T : ChestController
    {
        #region --------- Protected Variables ---------
        protected T Owner;
        protected IState currentState;
        protected Dictionary<ChestStates, IState> statesDict = new ();
        #endregion ------------------

        #region --------- Public Variables ---------
        #endregion ------------------

        #region --------- Protected Methods ---------
        protected void ChangeState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }
      
        protected virtual void CreateStates(){}

        protected void SetOwner()
        {
            foreach(IState state in statesDict.Values)
            {
                state.Owner = Owner;
            }
        }
        #endregion ------------------

        #region --------- Public Methods ---------
        public GenericStateMachine(T Owner) => this.Owner = Owner;

        public void ChangeState(ChestStates newState) => ChangeState(statesDict[newState]);

        public void Update() => currentState.Update();
        #endregion ------------------
    }
}
