using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandKillPet : CheatCommandBase
{
    public override string commandID { get; protected set; }
    public override string commandDescription { get; protected set; }
    //private GameObject _pet;
    //private PetDragonHealth _petDragonHealth;

    public CommandKillPet()
    {
        commandID = "kill_pet";
        commandDescription = "Kill pet";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        //_petDragonHealth.StartSinking();
    }

    public static CommandKillPet CreateCommand()
    {
        return new CommandKillPet();
    }
}