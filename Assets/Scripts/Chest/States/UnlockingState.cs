using UnityEngine;
using System.Collections;
using ChestSystem.Utilities;

namespace ChestSystem.Chest.States
{
    public class UnlockingState<T> : IState where T : ChestController
    {
        private GenericStateMachine<T> stateMachine;
        public UnlockingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public override void OnStateEnter()
        {
            Owner.View.StartChestUnlocking();
        }
    }
}
