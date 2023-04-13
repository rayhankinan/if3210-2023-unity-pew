using UnityEngine;

public class ShopKeeperEffect : MonoBehaviour
{
    public GameObject player;
    private Animator _anim;
    private Light _shopKeeperLight;
    private Rigidbody _shopKeeperRigidbody;
    private Vector3 _movement;
    private Vector3 _currentPosition;
    public float speed = 5f;
    public bool isShopKeeperFlying;
    private static readonly int ShopKeeperFlying = Animator.StringToHash("ShopKeeperFlying");

    // Start is called before the first frame update
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _shopKeeperLight = GetComponent<Light>();
        _shopKeeperRigidbody = GetComponent<Rigidbody>();
        
        var position = transform.position;
        _currentPosition.Set(position.x, position.y, position.z);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (isShopKeeperFlying)
        {
            _shopKeeperLight.enabled = true;

            if (transform.position.y < 3)
            {
                transform.Translate(Vector3.up * (speed * Time.deltaTime));
            }
        }
        else
        {
            _shopKeeperLight.enabled = false;
            if (transform.position.y > 0)
            {
                transform.Translate(Vector3.down * (speed * Time.deltaTime));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != player) return;
        
        isShopKeeperFlying = true;
        _anim.SetBool(ShopKeeperFlying, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != player) return;
        
        isShopKeeperFlying = false;
        _anim.SetBool(ShopKeeperFlying, false);
    }
}
