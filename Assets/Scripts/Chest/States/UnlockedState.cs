using ChestSystem.Utilities;

namespace ChestSystem.Chest.States
{
    public class UnlockedState<T> : IState where T : ChestController
    {
        private GenericStateMachine<T> stateMachine;

        public UnlockedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        private const string completedString = "COMPLETED";

        public override void OnStateEnter()
        {
            Owner.View.OnChestUnlocked(completedString,Owner.Model.OpenChestSprite);
        }
    }
}
