using ChestSystem.Chest;
using ChestSystem.Chest.States;
using System.Collections.Generic;

namespace ChestSystem.Utilities
{
    public class GenericStateMachine<T> where T : ChestController
    {
       // Protected Variables 
        protected T Owner;
        protected IState currentState;
        protected Dictionary<ChestStates, IState> statesDict = new ();

        // Constructor
        public GenericStateMachine(T Owner) => this.Owner = Owner;

        // Protected Methods 
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

        // Public Methods
        public void ChangeState(ChestStates newState) => ChangeState(statesDict[newState]);

        public void Update() => currentState.Update();
    }
}
