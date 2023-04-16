using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetDragonAttack : MonoBehaviour
{
    public GameObject projectile;
    NavMeshAgent nav;
    Animator _anim;
    Rigidbody dragonRigidBody;
    PetDragonMovement petDragonMovement;
    float _timeBetweenFireball = 0.1f;
    float _time;
    RaycastHit Hit;
    public float chaseRadius = 5f;
    int _shootableMask;

    // Start is called before the first frame update
    void Start()
    {
        _shootableMask = LayerMask.GetMask("Shootable");
        nav = GetComponent<NavMeshAgent>();
        _time = _timeBetweenFireball;
        _anim = GetComponent<Animator>();
        petDragonMovement = GetComponent<PetDragonMovement>();
        dragonRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _timeBetweenFireball)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (petDragonMovement.closestDamageable != null)
        {
            Debug.Log($"{petDragonMovement.closestDamageable.transform.position}");
            var enemyTransfom = petDragonMovement.closestDamageable.transform;
            var enemyPosition = new Vector3(enemyTransfom.position.x, 0, enemyTransfom.position.z);
            var dragonPosition = new Vector3(transform.position.x, 0, transform.position.z);
            if (Vector3.Distance(dragonPosition, enemyPosition) < chaseRadius)
            {
                if (HasLineOfSightTo(enemyTransfom))
                {
                    _anim.SetTrigger("Attack");
                    nav.enabled = false;
                    _time = 0;
                    GameObject fireball = Instantiate(projectile,
                        transform.position + (transform.rotation * (new Vector3(0, 1, 1.5f))),
                        transform.rotation * Quaternion.Euler(-90, 0, 0)
                    );
                }
                else
                {
                    _anim.SetTrigger("Attack");
                    nav.enabled = false;
                    _time = 0;
                    LookAt(petDragonMovement.closestDamageable.transform);
                    GameObject fireball = Instantiate(projectile,
                        transform.position + (transform.rotation * (new Vector3(0, 1, 1.5f))),
                        transform.rotation * Quaternion.Euler(-90, 0, 0)
                    );
                }
            }
            else
            {
                nav.enabled = true;
            }

        }
        else
        {
            nav.enabled = true;
        }
    }

    void LookAt(Transform target)
    {
        var targetVector = new Vector3(target.position.x, 0, target.position.z);
        var sourceVector = new Vector3(transform.position.x, 0, transform.position.z);
        Quaternion lookRotation = Quaternion.LookRotation(targetVector - sourceVector);
        dragonRigidBody.MoveRotation(Quaternion.Slerp(transform.rotation, lookRotation, 0.4f));
    }

    bool HasLineOfSightTo(Transform target)
    {    
        var enemyPosition = new Vector3(target.position.x, 0, target.position.z);
        var fireballOrigin = new Vector3(transform.position.x, 0, transform.position.z);
        if (Physics.SphereCast(fireballOrigin, 1.15f, (enemyPosition - fireballOrigin).normalized, out Hit, chaseRadius, _shootableMask))
        {
            EnemyHealth damageable;
            if (Hit.collider.TryGetComponent<EnemyHealth>(out damageable))
            {
                return damageable.transform == target;
            }
        }

        return false;
    }
}
