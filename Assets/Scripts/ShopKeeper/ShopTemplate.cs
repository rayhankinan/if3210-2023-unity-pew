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

        Debug.Log($"type = {type}");
        if (type == 0) // Weapon
        {
            int weaponType = 3;
            if (title.text == "Sword")
            {
                weaponType = 2;
            }
            else if (title.text == "Shotgun")
            {
                weaponType = 1;
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

            //Debug.Log("Add Pet");
            CurrentStateData.AddPet(petType);

            Debug.Log($"Length = {CurrentStateData.GetPetsLength()}");
            if (CurrentStateData.GetPetsLength() == 1)
            {
                //Debug.Log($"Pet Type = {petType}");
                PetManager.tryToSpawnNewPet = true;
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
            var weapons = CurrentStateData.GetWeapons();
            if (title.text == "Bow" && weapons[3])
            {
                buyButton.gameObject.SetActive(false);
            }
            if (title.text == "Sword" && weapons[2])
            {
                buyButton.gameObject.SetActive(false);
            }
            else if (title.text == "Shotgun" && weapons[1])
            {
                buyButton.gameObject.SetActive(false);
            }
            else
            {
                buyButton.gameObject.SetActive(true);

            }
        }
    }
}
