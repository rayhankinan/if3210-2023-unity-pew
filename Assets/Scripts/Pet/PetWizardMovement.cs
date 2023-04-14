using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetWizardMovement : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    public Transform target;
    public GameObject player;
    public float speed = 6f;
    NavMeshAgent nav;
    Animator _anim;
    bool move = false;
    bool _enemyInRange = false;
    Vector3 enemyPosition;
    Rigidbody _wizardRigidBody;
    Vector3 _movement;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _wizardRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if ((player.transform.position - transform.position).magnitude >= 5)
        {
            _anim.SetBool(IsWalking, true);
            //_anim.SetTrigger("Walk");
            Debug.Log("Move to player");
            nav.SetDestination(player.transform.position);
        }
        else
        {
            if (_enemyInRange)
            {
                //_anim.SetTrigger("Walk");
                _anim.SetBool(IsWalking, true);
                Debug.Log("Move from enemy");
                nav.SetDestination((enemyPosition * -1).normalized);
            }
            else
            {
                //_anim.SetTrigger("Idle");
                _anim.SetBool(IsWalking, false);
            }
        }
    }

    private void Turning()
    {
        // Mendapatkan vector dari posisi player dan posisi floorHit
        var wizardToEnemy = enemyPosition - transform.position;
        wizardToEnemy.y = 0f;

        // Mendapatkan look rotation baru ke hit position
        var newRotation = Quaternion.LookRotation(wizardToEnemy);

        // Rotasi player
        _wizardRigidBody.MoveRotation(newRotation);
    }

    private void Move(float h, float v)
    {
        // Set nilai x dan y
        _movement.Set(h, 0f, v);

        // Menormalisasi nilai vector agar total panjang dari vector adalah 1
        _movement = _movement.normalized * (speed * Time.deltaTime);

        // Move to position
        _wizardRigidBody.MovePosition(transform.position + _movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (
            other.gameObject.CompareTag("ZomBunny")
            || other.gameObject.CompareTag("ZomBear")
            || other.gameObject.CompareTag("Hellephant")
            )
        {
            enemyPosition = other.gameObject.transform.position;
            _enemyInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (
            other.gameObject.CompareTag("ZomBunny")
            || other.gameObject.CompareTag("ZomBear")
            || other.gameObject.CompareTag("Hellephant")
            )
        {
            _enemyInRange = false;
        }
    }
}
