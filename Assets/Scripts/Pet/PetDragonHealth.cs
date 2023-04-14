using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetDragonHealth : MonoBehaviour
{
    private static readonly int Dead = Animator.StringToHash("Dead");

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public AudioClip deathClip;
    private PetDragonMovement _petDragonMovement;
    private PetDragonAttack _petDragonAttack;
    private Animator _anim;
    private bool _isDead;
    private bool _isSinking;

    private void Awake()
    {
        // Mendapatkan reference komponen
        _anim = GetComponent<Animator>();
        _petDragonMovement = GetComponent<PetDragonMovement>();
        _petDragonAttack = GetComponent<PetDragonAttack>();
        currentHealth = startingHealth;
    }

    private void Update()
    {
        if (_isSinking)
        {
            // Memindahkan object kebawah
            transform.Translate(-Vector3.up * (sinkSpeed * Time.deltaTime));
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
        _petDragonAttack.enabled = false;
    }

    // Fungsi untuk mendapatkan damage
    public void TakeDamage(int amount)
    {
        // Mengurangi health
        currentHealth -= amount;

        // Memainkan suara ketika terkena damage
        //_petDragonAudio.Play();

        // Memanggil method Death() jika health <= 0 dan belum mati
        if (currentHealth <= 0 && !_isDead)
        {
            Death();
        }
    }

    public void StartSinking()
    {
        // Disable Navmesh Component
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        // Set rigidbody ke kinematic
        GetComponent<Rigidbody>().isKinematic = true;

        // Set isSinking
        _isSinking = true;

        // Destroy Object
        Destroy(gameObject, 2f);
    }
}
