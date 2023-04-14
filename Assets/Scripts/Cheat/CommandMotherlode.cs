using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMotherlode : CheatCommandBase
{
    public override string commandID { get; protected set; }
    public override string commandDescription { get; protected set; }

    public CommandMotherlode()
    {
        commandID = "motherlode";
        commandDescription = "Give infinite coins";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        CurrentStateData.AddCoin(999999);
    }

    public static CommandMotherlode CreateCommand()
    {
        return new CommandMotherlode();
    }
}