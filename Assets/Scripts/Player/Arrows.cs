using UnityEngine;

public class Arrows : MonoBehaviour
{
    [SerializeField]
    private int damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rigidbody;

    private float _multiplier;
    private bool _isHit;
    private bool oneHit;

    public void Fly(Vector3 force){
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null);
        
        _multiplier = CurrentStateData.GetMultiplier();
    }

    private void OnTriggerEnter(Collider collider) {
        if(_isHit) return;
        
        _isHit = true;
        var enemyHealth = collider.GetComponent<EnemyHealth>();
        if(enemyHealth){
            if (oneHit)
            {
                enemyHealth.TakeDamageSword(Mathf.RoundToInt(enemyHealth.currentHealth));
            }
            else
            {
                enemyHealth.TakeDamageSword(Mathf.RoundToInt(damage * _multiplier));
            }
        }

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;
        transform.SetParent(collider.transform);
    }
    
    public void SetOneHit()
    {
        oneHit = true;
    }
}
