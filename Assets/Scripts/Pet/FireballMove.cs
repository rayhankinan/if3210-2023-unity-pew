using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMove : MonoBehaviour
{
    public float speed = 10f;
    Vector3 initialPosition;
    int fireballDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - initialPosition).magnitude > 6.5)
        {
            Destroy(this.gameObject);
        } else
        {
            var direction = transform.rotation * (new Vector3(0, 0, -1));
            transform.Translate(direction * (speed * Time.deltaTime));

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth)
        {
            enemyHealth.TakeDamage(fireballDamage, transform.position);
            Destroy(this.gameObject);
        }
    }
}
