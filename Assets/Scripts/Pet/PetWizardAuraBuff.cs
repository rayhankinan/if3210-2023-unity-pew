using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetWizardAuraBuff : MonoBehaviour
{
    public GameObject player;
    public float buffMultiplier = 1.2f;
    bool _playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        if ((transform.position - player.transform.position).magnitude <= 6)
        {
            _playerInRange = true;
        }
        else
        {
            _playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.transform.position).magnitude <= 6)
        {
            _playerInRange = true;
        }
        else
        {
            _playerInRange = false;
        }

        if (!PauseManager.CheckIfPaused())
        {
            if (_playerInRange)
            {
                //Debug.Log(_timer);
                CurrentStateData.setMultiplier(buffMultiplier);
            }
            else
            {
                CurrentStateData.setMultiplier(1);
            }

        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        _playerInRange = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        _playerInRange = false;
    //    }
    //}
}
