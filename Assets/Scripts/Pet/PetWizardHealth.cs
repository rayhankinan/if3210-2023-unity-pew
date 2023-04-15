using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetWizardHealth : MonoBehaviour, IDamageableFriendly
{
    private static readonly int Dead = Animator.StringToHash("Dead");

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public GameObject spellEffect;
    public AudioClip deathClip;
    private PetWizardMovement _petWizardMovement;
    private PetWizardHeal _petWizardHeal;
    private Animator _anim;
    public bool _isDead;
    private bool _isSinking;
    private bool _immortal;

    private void Awake()
    {
        // Mendapatkan reference komponen
        _isDead = false;
        _anim = GetComponent<Animator>();
        _petWizardMovement = GetComponent<PetWizardMovement>();
        _petWizardHeal = GetComponent<PetWizardHeal>();
        currentHealth = startingHealth;
        _immortal = false;
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
        if (_petWizardHeal != null)
        {
            _petWizardHeal.enabled = false;
        }
        spellEffect.SetActive(false);
    }

    // Fungsi untuk mendapatkan damage
    public void TakeDamage(int amount)
    {
        if (!_immortal)
        {
            // Mengurangi health
            currentHealth -= amount;
        }
        
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

    public void Immortal()
    {
        _immortal = true;
    }
}
