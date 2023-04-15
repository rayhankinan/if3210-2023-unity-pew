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
    public GameObject enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _shopKeeperEffect = shopKeeper.GetComponent<ShopKeeperEffect>();
        shopKeeperCanvas.SetActive(false);
        _startTime = Time.time;
        PauseManager.StaticPauseOrUnPause();

        if (CurrentStateData.GetCurrentScene() == "level_01")
        {
            shopKeeper.SetActive(false);
            enemyManager.SetActive(true);
        }
        else
        {
            shopKeeper.SetActive(true);
            enemyManager.SetActive(false);
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
            enemyManager.SetActive(true);
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

        if (Input.GetKey(KeyCode.B) && !PauseManager.CheckIfPaused())
        {
            //Debug.Log("Press B");
            if (!_shopKeeperEffect.isShopKeeperFlying)
            {
                //Debug.Log("False");
                _anim.SetTrigger(BuyErrorClick);
            }
            else
            {
                //Debug.Log("True");
                PauseManager.StaticPauseOrUnPause();
                shopKeeperCanvas.SetActive(true);
            }
        }
    }
}
