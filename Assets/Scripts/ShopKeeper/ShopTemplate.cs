using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTemplate : MonoBehaviour
{
    public Text title;
    public Text description;
    public Text price;
    public Button buyButton;
    public int type; // 0 = Weapon, 1 = Pet
    public ShopKeeperCanvasManager manager;
    // Start is called before the first frame update
    void Start()
    {
        buyButton = GetComponentInChildren<Button>();
        buyButton.onClick.AddListener(buyItem);
        checkPurchasable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buyItem()
    {
        CurrentStateData.SubtractCoin(int.Parse(price.text));

        if (type == 0) // Weapon
        {
            int weaponType = 1;
            if (title.text == "Sword")
            {
                weaponType = 2;
            }
            else if (title.text == "Shotgun")
            {
                weaponType = 3;
            }

            CurrentStateData.AddWeapon(weaponType);

        }
        else if (type == 1) // Pet
        {
            int petType = 0;
            if (title.text == "Dragon")
            {
                petType = 1;
            }
            else if (title.text == "Buff Wizard")
            {
                petType = 2;
            }

            CurrentStateData.AddPet(petType);

            if (petType == 0)
            {
                Instantiate(manager.healerPet, manager.player.transform.position, manager.player.transform.rotation);
            }
            else if (petType == 1)
            {
                Instantiate(manager.attackerPet, manager.player.transform.position, manager.player.transform.rotation);
            }
            else if (petType == 2)
            {
                Instantiate(manager.buffPet, manager.player.transform.position, manager.player.transform.rotation);
            }
        }

        manager.BroadcastCheckPuchaseable();
    }

    public void checkPurchasable()
    {
        var itemPrice = int.Parse(price.text);
        if (CurrentStateData.GetCurrentCoin() < itemPrice)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
        }
    }
}
