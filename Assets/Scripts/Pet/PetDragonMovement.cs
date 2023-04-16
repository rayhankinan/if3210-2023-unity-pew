using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class PetDragonMovement : MonoBehaviour
{
    NavMeshAgent nav;
    Animator _anim;
    PetDragonAttack petDragonAttack;
    bool move = false;
    public List<EnemyHealth> Damageables = new List<EnemyHealth>();
    public EnemyHealth closestDamageable;
    Rigidbody dragonRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        petDragonAttack = GetComponent<PetDragonAttack>();
        dragonRigidBody = GetComponent<Rigidbody>();
    }

    void LookAt(Transform target)
    {
        //Debug.Log($"{target.position} - {transform.position}");
        var targetVector = new Vector3(target.position.x, 0, target.position.z);
        var sourceVector = new Vector3(transform.position.x, 0, transform.position.z);
        Quaternion lookRotation = Quaternion.LookRotation(targetVector - sourceVector);
        dragonRigidBody.MoveRotation(Quaternion.Slerp(transform.rotation, lookRotation, 0.4f));
    }

    // Update is called once per frame
    void Update()
    {
        move = false;

        if (Damageables.Count > 0)
        {
            if (closestDamageable == null)
            {
                float closestDistance = float.MaxValue;
                for (int i = 0; i < Damageables.Count; i++)
                {
                    var damagable = Damageables[i];
                    if (damagable != null)
                    {
                        var damagableTransform = damagable.transform;
                        float distance = Vector3.Distance(transform.position, damagableTransform.position);

                        if (distance < closestDistance)
                        {
                            closestDistance = distance;
                            closestDamageable = damagable;
                        }
                    }
                }
            }

            if (closestDamageable != null)
            {
                if (nav.enabled)
                {
                    move = true;
                    _anim.SetBool("IsMoving", move);
                    nav.SetDestination(closestDamageable.transform.position);
                }
            }
            else
            {
                _anim.SetBool("IsMoving", move);
            }
        }
        else
        {
            closestDamageable = null;
            _anim.SetBool("IsMoving", move);
        }

        if (closestDamageable == null || closestDamageable._isDead || closestDamageable.currentHealth < 0)
        {
            Damageables.Remove(closestDamageable);
            closestDamageable = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (
            other.CompareTag("ZomBear")
            || other.CompareTag("ZomBunny")
            || other.CompareTag("Hellephant")
            )
        {
            var enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                Damageables.Add(enemyHealth);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (
            other.CompareTag("ZomBear")
            || other.CompareTag("ZomBunny")
            || other.CompareTag("Hellephant")
            )
        {
            var enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                Damageables.Remove(enemyHealth);
            }
        }
    }
}
