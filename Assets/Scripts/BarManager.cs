using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    public GameObject barSlider;
    // Start is called before the first frame update
    void Start()
    {
        barSlider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentStateData.GetCurrentWeapon() == 3){
            barSlider.SetActive(true);
        }
        else
        {
            barSlider.SetActive(false);
        }
    }
}
