using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetWizardHealth : MonoBehaviour
{
    private static readonly int Dead = Animator.StringToHash("Dead");

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public AudioClip deathClip;
    private PetWizardMovement _petWizardMovement;
    private Animator _anim;
    private bool _isDead;
    private bool _isSinking;

    private void Awake()
    {
        // Mendapatkan reference komponen
        _isDead = false;
        _anim = GetComponent<Animator>();
        _petWizardMovement = GetComponent<PetWizardMovement>();
        currentHealth = startingHealth;
    }

    private void Update()
    {
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
        //_petWizardAudio.clip = deathClip;
        //_petWizardAudio.Play();

        // Mematikan script petWizard movement
        _petWizardMovement.enabled = false;
    }

    // Fungsi untuk mendapatkan damage
    public void TakeDamage(int amount)
    {
        // Mengurangi health
        currentHealth -= amount;

        // Memainkan suara ketika terkena damage
        //_petWizardAudio.Play();

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
