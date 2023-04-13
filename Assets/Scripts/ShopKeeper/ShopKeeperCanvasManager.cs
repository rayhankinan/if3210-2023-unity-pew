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
    // Start is called before the first frame update
    void Start()
    {
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
            Time.timeScale = 1;
        }   
    }

    public void LoadPanels()
    {
        for(int i = 0; i < shopItemsSO.Length; i++)
        {
            var shopPanel = shopPanels[i];
            var shopItemSO = shopItemsSO[i];

            shopPanel.title.text = shopItemSO.title;
            shopPanel.description.text = shopItemSO.description;
            shopPanel.price.text = shopItemSO.price.ToString();
        }
    }
}
