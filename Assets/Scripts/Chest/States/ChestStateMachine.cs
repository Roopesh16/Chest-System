using ChestSystem.Chest;
using ChestSystem.Utilities;
using ChestSystem.Chest.States;

public class ChestStateMachine : GenericStateMachine<ChestController>
{
    #region --------- Protected Methods ---------
    protected override void CreateStates()
    {
        statesDict.Add(ChestStates.LOCKED, new LockedState<ChestController>(this));
        statesDict.Add(ChestStates.UNLOCKING, new UnlockingState<ChestController>(this));
        statesDict.Add(ChestStates.UNLOCKED, new UnlockedState<ChestController>(this));

    }
    #endregion ------------------

    #region --------- Public Methods ---------
    public ChestStateMachine(ChestController Owner) : base(Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }
    #endregion ------------------
}
