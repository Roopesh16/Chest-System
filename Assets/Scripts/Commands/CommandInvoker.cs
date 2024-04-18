using System.Collections.Generic;
using UnityEngine;
using ChestSystem.Commands.Abstract;

public class CommandInvoker
{
    private Stack<ICommand> commandRegistry = new();

    public void ProcessCommand(ICommand commandToProcess)
    {
        ExecuteCommand(commandToProcess);
        RegisterCommand(commandToProcess);
        Debug.Log(commandRegistry.Count);
    }

    private void ExecuteCommand(ICommand command) => command.Execute();

    private void RegisterCommand(ICommand command) => commandRegistry.Push(command);
}
