using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandNoDamagePet : CheatCommandBase
{
    public override string commandID { get; protected set; }
    public override string commandDescription { get; protected set; }

    public CommandNoDamagePet()
    {
        commandID = "no_damage_pet";
        commandDescription = "Enemy attacks will not affect to pet health";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        
    }

    public static CommandNoDamagePet CreateCommand()
    {
        return new CommandNoDamagePet();
    }
}