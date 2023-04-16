    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public GameObject healerPet;
    public GameObject attackerPet;
    public GameObject buffPet;
    public static bool tryToSpawnNewPet = false;
    public static Transform nextTransform;

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
        if (tryToSpawnNewPet)
        {
            Debug.Log("Try to spawn pet");
            SpawnCurrentPetNearPlayer();
            tryToSpawnNewPet = false;
        }
    }

    public void SpawnCurrentPetNearPlayer()
    {
        int petType = CurrentStateData.GetCurrentPet();

        //Debug.Log($"CurrentStateData.GetCurrentPethealth() = {CurrentStateData.GetCurrentPethealth()}");
        if (petType != -1)
        {
            if (CurrentStateData.GetCurrentPethealth() <= 0 && !tryToSpawnNewPet)
            {
                CurrentStateData.RemoveCurrentPet();
                petType = CurrentStateData.GetCurrentPet();
                if (petType != - 1)
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
                    if (petHealth != null)
                    {
                        petHealth.SetManager(this);
                    }
                    else
                    {
                        Debug.Log("petHealth is null");
                    }
                }
            }
            else
            {
                GameObject pet = null;
                if (petType == 0)
                {
                    pet = Instantiate(healerPet, player.transform.position + (Vector3.right * 0.5f), player.transform.rotation);
                }
                else if (petType == 1)
                {
                    pet = Instantiate(attackerPet, player.transform.position + (Vector3.right * 0.5f), player.transform.rotation);
                }
                else if (petType == 2)
                {
                    pet = Instantiate(buffPet, player.transform.position + (Vector3.right * 0.5f), player.transform.rotation);
                }

                //Debug.Log($"petType  = {petType}");

                var petHealth = pet.GetComponent<PetHealth>();
                if (petHealth != null)
                {
                    //Debug.Log("petHealth != null");
                    petHealth.SetManager(this);
                }
                else
                {
                    Debug.Log("petHealth is null");
                }
            }
        }
    }

    public void TryToSpawnNextPet(Transform transform)
    {
        int petType = CurrentStateData.GetCurrentPet();

        //Debug.Log($"CurrentStateData.GetCurrentPethealth() = {CurrentStateData.GetCurrentPethealth()}");
        if (petType != -1)
        {
            GameObject pet = null;
            if (petType == 0)
            {
                pet = Instantiate(healerPet, transform.position, transform.rotation);
            }
            else if (petType == 1)
            {
                pet = Instantiate(attackerPet, transform.position, transform.rotation);
            }
            else if (petType == 2)
            {
                pet = Instantiate(buffPet, transform.position, transform.rotation);
            }


            var petHealth = pet.GetComponent<PetHealth>();
            if (petHealth != null)
            {
                petHealth.SetManager(this);
            }
        }
    }
}
