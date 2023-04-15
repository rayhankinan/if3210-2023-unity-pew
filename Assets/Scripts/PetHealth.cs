using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    protected PetManager manager;
    public int initialHealthReduced = 0;

    public void SetManager(PetManager manager)
    {
        this.manager = manager;
    }
}
