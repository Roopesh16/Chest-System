namespace ChestSystem.Chest.States
{
    public abstract class IState<T>
    {
        public T Owner;
        public virtual void OnStateEnter() { }

        public virtual void Update() { }

        public virtual void OnStateExit() { }
    }
}
