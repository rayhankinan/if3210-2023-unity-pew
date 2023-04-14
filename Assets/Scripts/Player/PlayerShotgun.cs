using UnityEngine;

public class PlayerShotgun : MonoBehaviour
{
    private const float EffectsDisplayTime = 0.2f;
    
    public int baseDamagePerShot = 10;
    public int pelletsPerShot = 7;
    public float timeBetweenBullets = 1.5f;
    public float range = 30f;
    public float maxDamageDistance = 10f;
    public float multiplier = CurrentStateData.getMultiplier();

    private float _timer;
    private Ray _shootRay;
    private RaycastHit _shootHit;
    private int _shootableMask;
    private ParticleSystem _gunParticles;
    private LineRenderer _gunLine;
    private AudioSource _gunAudio;
    private Light _gunLight;

    private void Awake()
    {
        _shootableMask = LayerMask.GetMask("Shootable");
        _gunParticles = GetComponent<ParticleSystem>();
        _gunLine = GetComponent<LineRenderer>();
        _gunAudio = GetComponent<AudioSource>();
        _gunLight = GetComponent<Light>();
    }

    private void Shoot()
    {
        _timer = 0f;

        _gunAudio.Play();

        _gunLight.enabled = true;

        _gunParticles.Stop();
        _gunParticles.Play();

        _gunLine.enabled = true;
        
        var position = transform.position;
        _gunLine.SetPosition(0, position);
        _shootRay.origin = position;
        
        for (var i = 0; i < pelletsPerShot; i++){
            var forward = transform.forward;
            var direction = forward + Random.insideUnitSphere * 0.2f;
            _shootRay.direction = direction;

            if (Physics.Raycast(_shootRay, out _shootHit, range, _shootableMask))
            {
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                var enemyHealth = _shootHit.collider.GetComponent<EnemyHealth>();

                if (enemyHealth)
                {
                    var distance = Vector3.Distance(transform.position, _shootHit.point);
                    var damageDistanceFactor = 1f - Mathf.Clamp01(distance / maxDamageDistance);
                    var damage = Mathf.RoundToInt(baseDamagePerShot * damageDistanceFactor);
                    enemyHealth.TakeDamage(damage*multiplier, _shootHit.point);
                }

                _gunLine.SetPosition(1, _shootHit.point);
            }
            else
            {
                _gunLine.SetPosition(1, _shootRay.origin + _shootRay.direction * range);
            }
        }
    }
    
    public void DisableEffects()
    {
        _gunLine.enabled = false;
        _gunLight.enabled = false;
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetButton($"Fire1") && _timer >= timeBetweenBullets && !PauseManager.CheckIfPaused())
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            Shoot();
        }

        if (_timer >= timeBetweenBullets * EffectsDisplayTime)
        {
            DisableEffects();
        }
    }
}