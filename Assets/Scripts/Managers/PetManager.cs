using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public GameObject healerPet;
    public GameObject attackerPet;
    public GameObject buffPet;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SpawnCurrentPetNearPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCurrentPetNearPlayer()
    {
        int petType = CurrentStateData.GetCurrentPet();

        Debug.Log($"CurrentStateData.GetCurrentPethealth() = {CurrentStateData.GetCurrentPethealth()}");
        if (petType != -1)
        {
            if (CurrentStateData.GetCurrentPethealth() <= 0)
            {
                CurrentStateData.RemoveCurrentPet();
                petType = CurrentStateData.GetCurrentPet();
                if (petType != - 1)
                {
                    GameObject pet = null;
                    if (petType == 0)
                    {
                        Instantiate(healerPet, player.transform.position + Vector3.right, player.transform.rotation);
                    }
                    else if (petType == 1)
                    {
                        Instantiate(attackerPet, player.transform.position + Vector3.right, player.transform.rotation);
                    }
                    else if (petType == 2)
                    {
                        Instantiate(buffPet, player.transform.position + Vector3.right, player.transform.rotation);
                    }

                    var petHealth = pet.GetComponent<PetHealth>();
                    petHealth.manager = this;
                }
            }
            else
            {
                GameObject pet = null;
                if (petType == 0)
                {
                    pet = Instantiate(healerPet, player.transform.position + Vector3.right, player.transform.rotation);
                }
                else if (petType == 1)
                {
                    pet = Instantiate(attackerPet, player.transform.position + Vector3.right, player.transform.rotation);
                }
                else if (petType == 2)
                {
                    pet = Instantiate(buffPet, player.transform.position + Vector3.right, player.transform.rotation);
                }


                var petHealth = pet.GetComponent<PetHealth>();
                petHealth.manager = this;
            }
        }
    }
}
