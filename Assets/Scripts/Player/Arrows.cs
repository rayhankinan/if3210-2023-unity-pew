using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    [SerializeField]
    private int damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rigidbody;

    private bool isHit;
    public float multiplier = CurrentStateData.getMultiplier();

    public void Fly(Vector3 force){
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }

    void OnTriggerEnter(Collider collider) {
        if(isHit) return;
        
        isHit = true;
        var enemyHealth = collider.GetComponent<EnemyHealth>();
        if(enemyHealth){
            enemyHealth.TakeDamageSword(damage * multiplier);
        }

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;
        transform.SetParent(collider.transform);
    }
}
