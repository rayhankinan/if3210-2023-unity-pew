using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandNoDamagePet : CheatCommandBase
{
    public override string commandID { get; protected set; }
    public override string commandDescription { get; protected set; }

    private GameObject healerPet;
    private GameObject attackerPet;
    private GameObject buffPet;
    private PetWizardHealth petWizardHealth;
    private PetDragonHealth petDragonHealth;
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
        if (currentPet != -1)
        {
            ImmortalPet(currentPet);
            //CurrentStateData.RemoveCurrentPet();
        }
    }

    private void ImmortalPet(int currentPet)
    {
        if (currentPet == 0)
        {
            healerPet = GameObject.FindGameObjectWithTag("Healing Wizard");
            petWizardHealth = healerPet.GetComponentInChildren<PetWizardHealth>();
            petWizardHealth.Immortal();
        }
        else if (currentPet == 1)
        {
            attackerPet = GameObject.FindGameObjectWithTag("Pet Dragon");
            petDragonHealth = attackerPet.GetComponentInChildren<PetDragonHealth>();
            petDragonHealth.Immortal();
        }
        else if (currentPet == 2)
        {
            buffPet = GameObject.FindGameObjectWithTag("Aura Buff Wizard");
            petWizardHealth = buffPet.GetComponentInChildren<PetWizardHealth>();
            petWizardHealth.Immortal();
        }
    }

    public static CommandNoDamagePet CreateCommand()
    {
        return new CommandNoDamagePet();
    }
}