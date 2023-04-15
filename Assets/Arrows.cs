using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float torque;
    [SerializeField] private Rigidbody rigidbody;
    private bool _isHit;
    private bool oneHit;

    public void Fly(Vector3 force, float firePower)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null);
        damage *= firePower;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (_isHit) return;
        _isHit = true;
        
        var enemyHealth = collider.GetComponent<EnemyHealth>();
        if (enemyHealth)
        {
            if (oneHit)
            {
                enemyHealth.TakeDamageSword(Mathf.RoundToInt(enemyHealth.currentHealth));
            }
            else
            {
                enemyHealth.TakeDamageSword(Mathf.RoundToInt(damage));
            }

            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.isKinematic = true;
            transform.SetParent(collider.transform);
        }

        var light = GetComponent<Light>();
        light.enabled = false;
    }

    public void SetOneHit()
    {
        oneHit = true;
    }
}
