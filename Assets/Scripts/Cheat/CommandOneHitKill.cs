using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandOneHitKill : CheatCommandBase
{
    public override string commandID { get; protected set; }
    public override string commandDescription { get; protected set; }
    private EnemyHealth _enemyHealth;

    public CommandOneHitKill()
    {
        commandID = "one_hit_kill";
        commandDescription = "Enemy will die instantly only by one hit";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        _enemyHealth.currentHealth = 1;
    }

    public static CommandOneHitKill CreateCommand()
    {
        return new CommandOneHitKill();
    }
}