using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandNoDamagePet : CheatCommandBase
{
    public override string commandID { get; protected set; }
    public override string commandDescription { get; protected set; }

    private GameObject petDragon; /*= GameObject.FindGameObjectWithTag("Pet Dragon");*/
    private GameObject petWizard; /*= GameObject.FindGameObjectWithTag("Aura Buff Wizard");*/
    private PetDragonHealth petDragonHealth;
    private PetWizardHealth petWizardHealth;
    private int currentPet;

    public CommandNoDamagePet()
    {
        commandID = "no_damage_pet";
        commandDescription = "Enemy attacks will not affect to pet health";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        currentPet = CurrentStateData.GetCurrentPet();
        if (currentPet == 0 || currentPet == 2)
        {
            petWizard = GameObject.FindGameObjectWithTag("Aura Buff Wizard");
            petWizardHealth = petDragon.GetComponent<PetWizardHealth>();
            petWizardHealth.Immortal();
        }
        else if (currentPet == 1)
        {
            petDragon = GameObject.FindGameObjectWithTag("Pet Dragon");
            petDragonHealth = petDragon.GetComponent<PetDragonHealth>();
            petDragonHealth.Immortal();
        }
        /*petDragonHealth = petDragon.GetComponentInChildren<PetDragonHealth>();
        petWizardHealth = petWizard.GetComponentInChildren<PetWizardHealth>();
        if (petDragon.gameObject.activeInHierarchy)
        {
            currentPet = 1;
        }
        else if (petWizard.gameObject.activeInHierarchy)
        {
            currentPet = 2;
            petWizardHealth.Immortal();
        }
        else
        {
            currentPet = -1;
        }
        Debug.Log(currentPet);*/
    }

    public static CommandNoDamagePet CreateCommand()
    {
        return new CommandNoDamagePet();
    }
}