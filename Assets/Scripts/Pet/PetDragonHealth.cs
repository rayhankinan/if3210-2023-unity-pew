using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetDragonHealth : PetHealth, IDamageableFriendly
{
    private static readonly int Dead = Animator.StringToHash("Dead");
    public float sinkSpeed = 2.5f;
    public AudioClip deathClip;
    private PetDragonMovement _petDragonMovement;
    private Animator _anim;
    private bool _isDead;
    private bool _isSinking;
    private bool _immortal;

    private void Awake()
    {
        // Mendapatkan reference komponen
        _isDead = false;
        _anim = GetComponent<Animator>();
        _petDragonMovement = GetComponent<PetDragonMovement>();
        currentHealth = startingHealth;
        _immortal = false;
    }

    private void Update()
    {
        if (CurrentStateData.GetCurrentPethealth() != -1 && currentHealth > CurrentStateData.GetCurrentPethealth())
        {
            Debug.Log("reduce");
            TakeDamage(startingHealth - CurrentStateData.GetCurrentPethealth());
        }

        if (_isSinking)
        {
            // Memindahkan object kebawah
            transform.Translate(Vector3.down * (sinkSpeed * Time.deltaTime));
        }
    }

    private void Death()
    {
        _isDead = true;

        // Mentrigger animasi Die
        _anim.SetTrigger(Dead);

        // Memainkan suara ketika mati
        //_petDragonAudio.clip = deathClip;
        //_petDragonAudio.Play();

        // Mematikan script petDragon movement
        _petDragonMovement.enabled = false;
    }

    // Fungsi untuk mendapatkan damage
    public void TakeDamage(int amount)
    {
        //Debug.Log("Take Damage");
        if (!_immortal)
        {
            // Mengurangi health
            currentHealth -= amount;
            CurrentStateData.SetCurrentPethealth(currentHealth);
        }

        // Memainkan suara ketika terkena damage
        //_petDragonAudio.Play();

        // Memanggil method Death() jika health <= 0 dan belum mati
        if (currentHealth <= 0 && !_isDead)
        {
            CurrentStateData.SetCurrentPethealth(-1);
            Death();
        }
        //Debug.Log($"CurrentStateData.GetCurrentPethealth() = {CurrentStateData.GetCurrentPethealth()}");
    }

    public void StartSinking()
    {
        CurrentStateData.RemoveCurrentPet();
        // Disable Navmesh Component
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        // Set rigidbody ke kinematic
        GetComponent<Rigidbody>().isKinematic = true;

        // Set isSinking
        _isSinking = true;

        manager.TryToSpawnNextPet(transform);
        // Destroy Object
        Destroy(gameObject, 2f);
    }
    
    public void Immortal()
    {
        _immortal = true;
    }
}
