using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    private int selectedWeapon;

    // Start is called before the first frame update
    private void Start()
    {
        selectedWeapon = CurrentStateData.GetCurrentWeapon();
    }

    // Update is called once per frame
    private void Update()
    {
        var previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f){
            if(selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f){
            if(selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2){
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3){
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4){
            selectedWeapon = 3;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            selectedWeapon = CurrentStateData.GetCurrentWeapon();
        }
        
    }
}
