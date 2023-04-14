using UnityEngine;

public class Arrows : MonoBehaviour
{
    [SerializeField]
    private int damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private new Rigidbody rigidbody;

    private float _multiplier;
    private bool _isHit;

    public void Fly(Vector3 force){
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null);
        
        _multiplier = CurrentStateData.GetMultiplier();
    }

    private void OnTriggerEnter(Collider objectCollider) {
        if(_isHit) return;
        
        _isHit = true;
        var enemyHealth = objectCollider.GetComponent<EnemyHealth>();
        if(enemyHealth){
            enemyHealth.TakeDamageSword(Mathf.RoundToInt(damage * _multiplier));
        }

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;
        transform.SetParent(objectCollider.transform);
    }
}
