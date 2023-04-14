using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetDragonAttack : MonoBehaviour
{
    public GameObject projectile;
    Animator _anim;
    Rigidbody dragonRigidBody;
    int frameBetweenFire = 15;
    bool attack = false;
    int frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        dragonRigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frame > 15)
        {
            frame = 0;
        } 
        else
        {
            frame++; 
        }
        //Debug.Log($"frame = {frame}");

        if (attack && frame == frameBetweenFire)
        {
            Attack();
        }
    }

    public void TryToAttack(Vector3 enemyPosition)
    {
        if (!attack)
        {
            enemyPosition.y = 0;
            var rotation = Quaternion.LookRotation(enemyPosition - transform.position);
            dragonRigidBody.MoveRotation(rotation);
            //Debug.Log("Try to attack");
            AttackStart();
        }
    }

    void AttackStart()
    {
        attack = true;
        _anim.SetTrigger("Attack");
    }

    void Attack()
    {
        //Debug.Log("Spawn fireball");
        frame = 0;
        attack = false;
        GameObject fireball = Instantiate(projectile,
            transform.position + (transform.rotation * (new Vector3(0, 1, 1.5f))),
            transform.rotation * Quaternion.Euler(-90, 0, 0)
            );
    }
}
