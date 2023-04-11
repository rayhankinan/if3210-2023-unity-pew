using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperManager : MonoBehaviour
{
    private static readonly int BuyClick = Animator.StringToHash("BuyClick");

    private Animator _anim;
    private float _restartTimer;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            _anim.SetTrigger(BuyClick);
        }
    }
}
