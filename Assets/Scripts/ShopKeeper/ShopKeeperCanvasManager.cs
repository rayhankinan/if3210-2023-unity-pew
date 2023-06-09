using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeperCanvasManager : MonoBehaviour
{
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] buyButtons;
    public GameObject player;
    public GameObject healerPet;
    public GameObject attackerPet;
    public GameObject buffPet;
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coinText.text = CurrentStateData.GetCurrentCoin().ToString();

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            var shopPanelGO = shopPanelsGO[i];
            shopPanelGO.gameObject.SetActive(true);
        }

        LoadPanels();
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKey(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            PauseManager.StaticPauseOrUnPause();
        }   
    }

    public void LoadPanels()
    {
        for(int i = 0; i < shopItemsSO.Length; i++)
        {
            var shopPanel = shopPanels[i];
            var shopItemSO = shopItemsSO[i];
            shopPanel.type = shopItemsSO[i].type == "Weapon" ? 0 : 1;
            shopPanel.title.text = shopItemSO.title;
            shopPanel.description.text = shopItemSO.description;
            shopPanel.price.text = shopItemSO.price.ToString();
            shopPanel.manager = this;
        }
    }

    public void BroadcastCheckPuchaseable()
    {
        coinText.text = CurrentStateData.GetCurrentCoin().ToString();

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            var shopPanel = shopPanels[i];
            shopPanel.checkPurchasable();
        }
    }
}
