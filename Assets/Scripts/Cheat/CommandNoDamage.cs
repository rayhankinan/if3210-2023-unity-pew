using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandNoDamage : CheatCommandBase
{
    public override string commandID { get; protected set; }
    public override string commandDescription { get; protected set; }
    private GameObject player = GameObject.FindGameObjectWithTag("Player");
    private PlayerHealth playerHealth;

    public CommandNoDamage()
    {
        commandID = "no_damage";
        commandDescription = "Enemy attacks will not affect to player health";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.Immortal();
    }

    public static CommandNoDamage CreateCommand()
    {
        return new CommandNoDamage();
    }
}