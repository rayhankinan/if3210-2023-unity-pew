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
    public GameObject shopKeeperCanvas;
    private float _startTime;
    public float timeLimit;
    PauseManager pauseManager;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _shopKeeperEffect = shopKeeper.GetComponent<ShopKeeperEffect>();
        shopKeeperCanvas.SetActive(false);
        _startTime = Time.time;
        pauseManager = new PauseManager();

        if (CurrentStateData.GetCurrentScene() == "level_01")
        {
            shopKeeper.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!shopKeeper.activeSelf)
        {
            return;
        }
        
        if ((Time.time - _startTime) > (timeLimit + 5))
        {
            shopKeeper.SetActive(false);
            _anim.SetBool("ShopKeeperAlive", false);
            return;
        }
        
        if (Time.time - _startTime > timeLimit)
        {
            _shopKeeperEffect.isShopKeeperFlying = true;
            _shopKeeperEffect.floatHeight = 15;
            return;
        }
        
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
            Debug.Log("Press B");
            if (!_shopKeeperEffect.isShopKeeperFlying)
            {
                Debug.Log("False");
                _anim.SetTrigger(BuyErrorClick);
            }
            else
            {
                Debug.Log("True");
                pauseManager.Pause();
                shopKeeperCanvas.SetActive(true);
            }
        }
    }
}
