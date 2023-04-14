using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;

    [SerializeField]
    private float maxFirePower;

    [SerializeField]
    private float firePowerSpeed;

    private float firePower;

    private bool fire;

    // Start is called before the first frame update
    void Start()
    {
        weapon.Reload();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            fire = true;
        }

        if(fire && firePower < maxFirePower){
            firePower += Time.deltaTime * firePowerSpeed;
        }

        if(fire && Input.GetMouseButtonUp(1)){
            weapon.Fire(firePower);
            firePower = 0;
            fire = false;
        }
    }
}
