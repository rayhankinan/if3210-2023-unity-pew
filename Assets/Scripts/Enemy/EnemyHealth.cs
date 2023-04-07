using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private static readonly int Dead = Animator.StringToHash("Dead");
    
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public int coinValue = 1;
    public AudioClip deathClip;

    private Animator _anim;
    private AudioSource _enemyAudio;
    private ParticleSystem _hitParticles;
    private CapsuleCollider _capsuleCollider;
    private bool _isDead;
    private bool _isSinking;
    
    private void Awake()
    {
        // Mendapatkan reference komponen
        _anim = GetComponent<Animator>();
        _enemyAudio = GetComponent<AudioSource>();
        _hitParticles = GetComponentInChildren<ParticleSystem>();
        _capsuleCollider = GetComponent<CapsuleCollider>();

        // Set current health
        currentHealth = startingHealth;
    }

    private void Update()
    {
        // Check jika sinking
        if (_isSinking)
        {
            // Memindahkan object kebawah
            transform.Translate(-Vector3.up * (sinkSpeed * Time.deltaTime));
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // Check jika dead
        if (_isDead)
            return;

        // Play audio
        _enemyAudio.Play();

        // Kurangi health
        currentHealth -= amount;

        // Ganti posisi particle
        _hitParticles.transform.position = hitPoint;
        
        // Play particle system
        _hitParticles.Play();

        // Dead jika health <= 0
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    
    private void Death()
    {
        // Set isDead
        _isDead = true;

        // SetCapcollider ke trigger
        _capsuleCollider.isTrigger = true;

        // Trigger play animation Dead
        _anim.SetTrigger(Dead);

        // Play Sound Dead
        _enemyAudio.clip = deathClip;
        _enemyAudio.Play();
    }
    
    public void StartSinking()
    {
        // Disable Navmesh Component
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        
        // Set rigidbody ke kinematic
        GetComponent<Rigidbody>().isKinematic = true;
        
        // Set isSinking
        _isSinking = true;
        
        // Add Score
        ScoreManager.score += scoreValue;
        
        // Add Coin
        CoinManager.coin += coinValue;
        
        // Add Enemy to Quest
        Quest.AddEnemy(gameObject);
        
        // Destroy Object
        Destroy(gameObject, 2f);
    }
}
