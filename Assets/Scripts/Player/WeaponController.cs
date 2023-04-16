using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponController : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private Weapon weapon;

    [SerializeField] private float maxFirePower;

    [SerializeField] private float firePowerSpeed;

    private float firePower;

    private float mouseY;
    private bool fire;
    
    // Start is called before the first frame update
    void Start()
    {
        weapon.Reload();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            fire = true;
        }

        if (fire && firePower < maxFirePower)
        {
            firePower += Time.deltaTime * firePowerSpeed;
            slider.value = firePower;
        }

        if (fire && Input.GetMouseButtonUp(1))
        {
            weapon.Fire(firePower);
            firePower = 0;
            fire = false;
            slider.value = firePower;
        }
    }
}
