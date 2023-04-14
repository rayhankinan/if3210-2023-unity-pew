using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 25;
    private RaycastHit _attackHit;

    private void OnTriggerEnter(Collider collider)
    {
        var enemyHealth = collider.GetComponent<EnemyHealth>();
        if(enemyHealth){
            enemyHealth.TakeDamageSword(damage);
        }
    }
}
