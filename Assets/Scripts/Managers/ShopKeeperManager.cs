using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperManager : MonoBehaviour
{
    private static readonly int BuyClick = Animator.StringToHash("BuyClick");
    private static readonly int BuyErrorClick = Animator.StringToHash("BuyErrorClick");

    public GameObject shopKeeper;
    private Animator _anim;
    private ShopKeeperEffect _shopKeeperEffect;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _shopKeeperEffect = shopKeeper.GetComponent<ShopKeeperEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_shopKeeperEffect.isShopKeeperFlying)
        {
            _anim.SetBool("ShopKeeperFlying", true);
        }
        else
        {
            _anim.SetBool("ShopKeeperFlying", false);
        }

        if (Input.GetKey(KeyCode.B))
        {
            if (!_shopKeeperEffect.isShopKeeperFlying)
            {
                _anim.SetTrigger(BuyErrorClick);
            }
        }
    }
}
