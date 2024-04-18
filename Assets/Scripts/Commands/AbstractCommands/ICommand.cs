namespace ChestSystem.Commands.Abstract
{
    public interface ICommand
    {
        public void Execute();
        public void Undo();
    }
}
