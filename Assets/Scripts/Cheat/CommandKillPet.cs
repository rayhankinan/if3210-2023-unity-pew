using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandKillPet : CheatCommandBase
{
    public override string commandID { get; protected set; }
    public override string commandDescription { get; protected set; }
    private GameObject healerPet;
    private GameObject attackerPet;
    private GameObject buffPet;
    private PetWizardHealth petWizardHealth;
    private PetDragonHealth petDragonHealth;
    private ShopKeeperCanvasManager manager;

    public CommandKillPet()
    {
        commandID = "kill_pet";
        commandDescription = "Instantly killing current pet";
        
        AddCommandToConsole();
    }

    public override void RunCommand()
    {
        int currentPet = CurrentStateData.GetCurrentPet();
        if (currentPet != -1)
        {
            KillPet(currentPet);
            CurrentStateData.RemoveCurrentPet();
            currentPet = CurrentStateData.GetCurrentPet();
        }
    }

    private void KillPet(int currentPet)
    {
        if (currentPet == 0)
        {
            healerPet = GameObject.FindGameObjectWithTag("Healing Wizard");
            petWizardHealth = healerPet.GetComponentInChildren<PetWizardHealth>();
            petWizardHealth.TakeDamage(petWizardHealth.currentHealth);
        }
        else if (currentPet == 1)
        {
            attackerPet = GameObject.FindGameObjectWithTag("Pet Dragon");
            petDragonHealth = healerPet.GetComponentInChildren<PetDragonHealth>();
            petDragonHealth.TakeDamage(petDragonHealth.currentHealth);
        }
        else if (currentPet == 2)
        {
            buffPet = GameObject.FindGameObjectWithTag("Aura Buff Wizard");
            petWizardHealth = buffPet.GetComponentInChildren<PetWizardHealth>();
            petWizardHealth.TakeDamage(petWizardHealth.currentHealth);
        }
    }

    public static CommandKillPet CreateCommand()
    {
        return new CommandKillPet();
    }
}