using System;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 25;
    private RaycastHit _attackHit;
    private float _multiplier;
    private bool oneHit;

    private void Awake()
    {
        _multiplier = CurrentStateData.GetMultiplier();
        oneHit = false;
    }

    private void OnTriggerEnter(Collider objectCollider)
    {
        var enemyHealth = objectCollider.GetComponent<EnemyHealth>();
        
        if (enemyHealth){
            if (oneHit)
            {
                enemyHealth.TakeDamageSword(Mathf.RoundToInt(enemyHealth.currentHealth));
            }
            else
            {
                _multiplier = CurrentStateData.GetMultiplier();
                enemyHealth.TakeDamageSword(Mathf.RoundToInt(damage * _multiplier));
            }
        }
    }
    
    public void SetOneHit()
    {
        oneHit = true;
    }
}
