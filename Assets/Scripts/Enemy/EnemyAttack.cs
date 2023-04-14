using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    private static readonly int PlayerDead = Animator.StringToHash("PlayerDead");
    private static readonly int WizardAttack = Animator.StringToHash("Attack");
    
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    private Animator _anim;
    private GameObject _player;
    private PlayerHealth _playerHealth;
    private PetDragonHealth _petDragonHealth;
    private EnemyHealth _enemyHealth;
    private bool _playerInRange;
    private bool _dragonPetInRange;
    private float _timer;

    private void Awake()
    {
        // Mencari game object dengan tag "Player"
        _player = GameObject.FindGameObjectWithTag("Player");
        
        // Mendapatkan komponen player health
        _playerHealth = _player.GetComponent<PlayerHealth>();
        
        // Mendapatkan Enemy health
        _enemyHealth = GetComponent<EnemyHealth>();
        
        // Mendapatkan komponen Animator
        _anim = GetComponent<Animator>();
    }

    // Callback jika ada suatu object masuk kedalam trigger
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.layer} - {LayerMask.GetMask("Pet")}");
        // Set player in range
        if (other.gameObject == _player)
        {
            _playerInRange = true;
        }
        else if (other.gameObject.CompareTag("Pet Dragon"))
        {
            Debug.Log("Pet collide Pet dragon");
            _petDragonHealth = other.gameObject.GetComponent<PetDragonHealth>();
            _dragonPetInRange = true;
        }
    }

    // Callback jika ada object yang keluar dari trigger
    private void OnTriggerExit(Collider other)
    {
        // Set player not in range
        if (other.gameObject == _player)
        {
            _playerInRange = false;
        }
        else if  (other.gameObject.CompareTag("Pet Dragon"))
        {
            _dragonPetInRange = false;
        }
    }


    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= timeBetweenAttacks && (_playerInRange || _dragonPetInRange) && _enemyHealth.currentHealth > 0)
        {
            if (gameObject.tag == "Wizard")
            {
                _anim.SetTrigger(WizardAttack);
            }
            Attack();
        }

        // Mentrigger animasi PlayerDead jika darah player kurang dari sama dengan 0
        if (_playerHealth.currentHealth <= 0)
        {
            _anim.SetTrigger(PlayerDead);
        }
    }


    private void Attack()
    {
        // Reset timer
        _timer = 0f;

        // Taking Damage
        if (_playerInRange)
        {
            if (_playerHealth.currentHealth > 0)
            {
                _playerHealth.TakeDamage(attackDamage);
            }
        }

        if (_dragonPetInRange)
        {
            if (_petDragonHealth.currentHealth > 0)
            {
                _petDragonHealth.TakeDamage(attackDamage);
            }
        }
    }
}
