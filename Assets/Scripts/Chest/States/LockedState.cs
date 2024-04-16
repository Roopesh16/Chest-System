using ChestSystem.Utilities;

namespace ChestSystem.Chest.States
{
    public class LockedState<T> : IState where T : ChestController
    {
        private GenericStateMachine<T> stateMachine;
        public LockedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;
    }
}
