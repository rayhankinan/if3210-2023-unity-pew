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
    private GameObject player;
    private PlayerShooting defaultWeapon;
    private PlayerShotgun shotgunWeapon;
    private AttackArea swordWeapon;
    private Arrows bowWeapon;
    private int currentWeapon;

    public CommandOneHitKill()
    {
        commandID = "one_hit_kill";
        commandDescription = "Enemy will die instantly only by one hit";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentWeapon = CurrentStateData.GetCurrentWeapon();
        OneHitKillWeapon(currentWeapon);
    }

    private void OneHitKillWeapon(int currentWeapon)
    {
        if (currentWeapon == 0)
        {
            defaultWeapon = player.GetComponentInChildren<PlayerShooting>();
            defaultWeapon.SetOneHit();
        }
        else if (currentWeapon == 1)
        {
            shotgunWeapon = player.GetComponentInChildren<PlayerShotgun>();
            shotgunWeapon.SetOneHit();
        }
        else if (currentWeapon == 2)
        {
            swordWeapon = player.GetComponentInChildren<AttackArea>();
            swordWeapon.SetOneHit();
        }
        else if (currentWeapon == 3)
        {
            bowWeapon = player.GetComponentInChildren<Arrows>();
            bowWeapon.SetOneHit();
        }
    }
    
    public static CommandOneHitKill CreateCommand()
    {
        return new CommandOneHitKill();
    }
}