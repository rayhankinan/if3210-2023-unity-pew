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
    int countEnemyInRange = 0;
    bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        petDragonAttack = GetComponent<PetDragonAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        move = false;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 9.5f, LayerMask.GetMask("Shootable"));
        hitColliders = hitColliders.Where(e => e.CompareTag("ZomBear") || e.CompareTag("ZomBunny") || e.CompareTag("Hellephant")).ToArray();
        //Debug.Log($"Length = {hitColliders.Length}");
        if (hitColliders.Length == 0)
        {
            _anim.SetTrigger("Idle");
        }
        else
        {
            if ((hitColliders[0].transform.position - transform.position).magnitude > 5.5)
            {
                if (!move)
                {
                    move = true;
                    _anim.SetTrigger("Move");
                }
                nav.SetDestination(hitColliders[0].transform.position);
            }
            else
            {
                petDragonAttack.TryToAttack(hitColliders[0].transform.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (
            other.CompareTag("ZomBear")
            || other.CompareTag("ZomBunny")
            || other.CompareTag("Hellpehant")
            )
        {
            countEnemyInRange++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (
            other.CompareTag("ZomBear") 
            || other.CompareTag("ZomBunny") 
            || other.CompareTag("Hellpehant")
            )
        {
            countEnemyInRange--;
        }
    }
}
