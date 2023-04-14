using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private static readonly int Die = Animator.StringToHash("Die");
    
    public int startingHealth = 100;
    public int currentHealth;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new(1f, 0f, 0f, 0.1f);

    private Animator _anim;
    private AudioSource _playerAudio;
    private PlayerMovement _playerMovement;
    private PlayerShooting _playerShooting;
    private PlayerShotgun _playerShotgun;
    private bool _isDead;
    private bool _damaged;

    private void Awake()
    {
        // Mendapatkan reference komponen
        _anim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShooting = GetComponentInChildren<PlayerShooting>();
        _playerShotgun = GetComponentInChildren<PlayerShotgun>();

        currentHealth = startingHealth;
    }

    private void Update()
    {
        // Jika terkena damage maka mengubah warna gambar menjadi value dari flashColour
        // Jika tidak terkena damage maka fade out damage image
        damageImage.color = _damaged ? flashColour : Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        _damaged = false;
    }

    private void Death()
    {
        _isDead = true;
        
        _playerShooting.DisableEffects();
        _playerShotgun.DisableEffects();
        
        // Mentrigger animasi Die
        _anim.SetTrigger(Die);
        
        // Memainkan suara ketika mati
        _playerAudio.clip = deathClip;
        _playerAudio.Play();
        
        // Mematikan script player movement
        _playerMovement.enabled = false;
        _playerShooting.enabled = false;
        _playerShotgun.enabled = false;
    }
    
    // Fungsi untuk mendapatkan damage
    public void TakeDamage(int amount)
    {
        _damaged = true;
        
        // Mengurangi health
        currentHealth -= amount;

        // Memainkan suara ketika terkena damage
        _playerAudio.Play();

        // Memanggil method Death() jika health <= 0 dan belum mati
        if (currentHealth <= 0 && !_isDead)
        {
            Death();
        }
    }

    public void TakeHealth(int amount)
    {
        Debug.Log("Heal Player");
        if (currentHealth + amount >= startingHealth)
        {
            _damaged = false;
            currentHealth = startingHealth;
        }
        else
        {
            currentHealth += amount;
        }
    }
}
