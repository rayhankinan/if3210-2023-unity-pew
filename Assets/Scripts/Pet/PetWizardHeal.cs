using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetWizardHeal : MonoBehaviour
{
    public GameObject player;
    public float timeBetweenHeal = 10f;
    public int healAmount = 10;
    float _timer;
    PlayerHealth playerHealth;
    bool _playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_playerInRange && _timer >= timeBetweenHeal && !PauseManager.CheckIfPaused())
        {
            Debug.Log(_timer);
            Heal();
        }
    }

    void Heal()
    {
        _timer = 0f;
        playerHealth.TakeHealth(healAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            _playerInRange = false;
        }
    }
}
