using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandOneHitKill : CheatCommandBase
{
    public override string commandID { get; protected set; }
    public override string commandDescription { get; protected set; }
    //private GameObject enemy = GameObject.FindGameObjectWithTag("Player");
    //EnemyHealth playerHealth
    //private RaycastHit raycastHit;
    //EnemyHealth enemyHealth;
        //= raycastHit.collider.GetComponent<EnemyHealth>();
    private GameObject player = GameObject.FindGameObjectWithTag("Player");
    private PlayerShooting playerShooting;

    public CommandOneHitKill()
    {
        commandID = "one_hit_kill";
        commandDescription = "Enemy will die instantly only by one hit";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        playerShooting = player.GetComponentInChildren<PlayerShooting>();
        playerShooting.SetOneHit();
    }

    public static CommandOneHitKill CreateCommand()
    {
        return new CommandOneHitKill();
    }
}