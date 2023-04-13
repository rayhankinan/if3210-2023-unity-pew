using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandDoubleSpeed : CheatCommandBase
{
    public override string commandID { get; protected set; }
    public override string commandDescription { get; protected set; }
    private GameObject _player;
    private PlayerMovement _playerMovement;

    public CommandDoubleSpeed()
    {
        commandID = "double_speed";
        commandDescription = "Player will move with double speed";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        _playerMovement.speed *= 2;
    }

    public static CommandNoDamage CreateCommand()
    {
        return new CommandNoDamage();
    }
}