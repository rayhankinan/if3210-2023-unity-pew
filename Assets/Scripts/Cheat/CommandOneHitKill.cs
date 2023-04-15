using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private PlayerShotgun playerShotgun;
    private AttackArea playerSword;
    private int selectedWeapon = CurrentStateData.GetCurrentWeapon();

    public CommandOneHitKill()
    {
        commandID = "one_hit_kill";
        commandDescription = "Enemy will die instantly only by one hit";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        //default weapon
        if (selectedWeapon == 0)
        {
            playerShooting = player.GetComponentInChildren<PlayerShooting>();
            playerShooting.SetOneHit();
        }
        
        //shotgun
        else if (selectedWeapon == 1)
        {
            playerShotgun = player.GetComponentInChildren<PlayerShotgun>();
            playerShotgun.SetOneHit();
        }
        
        //sword
        else if (selectedWeapon == 2)
        {
            playerSword = player.GetComponentInChildren<AttackArea>();
            playerSword.SetOneHit();
        }
    }

    public static CommandOneHitKill CreateCommand()
    {
        return new CommandOneHitKill();
    }
}