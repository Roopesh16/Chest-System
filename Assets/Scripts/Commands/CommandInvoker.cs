using System.Collections.Generic;
using ChestSystem.Commands.Abstract;

public class CommandInvoker
{
    private Stack<ICommand> commandRegistry = new();

    public void ProcessCommand(ICommand commandToProcess)
    {
        ExecuteCommand(commandToProcess);
        RegisterCommand(commandToProcess);
    }

    public void ExecuteCommand(ICommand command) => command.Execute();

    public void RegisterCommand(ICommand command) => commandRegistry.Push(command);
}
