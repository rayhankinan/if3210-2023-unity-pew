using System;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 25;
    private RaycastHit _attackHit;
    private float _multiplier;

    private void Awake()
    {
        _multiplier = CurrentStateData.GetMultiplier();
    }

    private void OnTriggerEnter(Collider objectCollider)
    {
        var enemyHealth = objectCollider.GetComponent<EnemyHealth>();
        
        if (enemyHealth){
            enemyHealth.TakeDamageSword(Mathf.RoundToInt(damage * _multiplier));
        }
    }
}
