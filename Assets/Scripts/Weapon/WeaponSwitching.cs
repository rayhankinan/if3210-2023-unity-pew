using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    private int selectedWeapon = CurrentStateData.GetCurrentWeapon();

    // Start is called before the first frame update
    private void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    private void Update()
    {
        var previousSelectedWeapon = selectedWeapon;
        var count = 0;
        var myWeapon = CurrentStateData.GetWeapons();
        foreach (bool i in myWeapon)
        {
            if (i)
            {
                count++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f){
            if (count != 1)
            {
                if (selectedWeapon == 0)
                {
                    selectedWeapon = 3;
                    while (myWeapon[selectedWeapon] == false)
                    {
                        selectedWeapon--;
                    }
                }
                else
                {
                    selectedWeapon--;
                    while (myWeapon[selectedWeapon] == false)
                    {
                        selectedWeapon--;
                    }
                }
            }
            
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (count != 1)
            {
                if (selectedWeapon == 3)
                {
                    selectedWeapon = 0;
                }
                else
                {
                    selectedWeapon++;
                    while (!myWeapon[selectedWeapon])
                    {
                        if (selectedWeapon == 3)
                        {
                            selectedWeapon = 0;
                        }
                        else
                        {
                            selectedWeapon++;
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && myWeapon[1]){
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 && myWeapon[2]){
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4 && myWeapon[3]){
            selectedWeapon = 3;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

        CurrentStateData.SetCurrentWeapon(selectedWeapon);
    }

    void SelectWeapon(){
        int i = 0;
        foreach(Transform weapon in transform){
            if(i == selectedWeapon){
                weapon.gameObject.SetActive(true);
            }else{
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
        CurrentStateData.SetCurrentWeapon(selectedWeapon);
    }
}
