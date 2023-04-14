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
        var myWeapon = CurrentStateData.GetWeapons();

        if (Input.GetAxis("Mouse ScrollWheel") > 0f){
            if(selectedWeapon <= 0)
                selectedWeapon = 3;
            else
                selectedWeapon--;
            while(!myWeapon[selectedWeapon]){
                selectedWeapon--;
                Debug.Log(selectedWeapon);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f){
            if(selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
            while(!myWeapon[selectedWeapon]){
                selectedWeapon++;
                Debug.Log(selectedWeapon);
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
