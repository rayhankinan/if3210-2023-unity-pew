using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandKillPet : CheatCommandBase
{
    public override string commandID { get; protected set; }
    public override string commandDescription { get; protected set; }

    public CommandKillPet()
    {
        commandID = "kill_pet";
        commandDescription = "Instantly killing current pet";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        CurrentStateData.RemoveCurrentPet();
    }

    public static CommandKillPet CreateCommand()
    {
        return new CommandKillPet();
    }
}