using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool isAttack = false;

    private float timeToAttack = 0.25f;
    private float _timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton($"Fire1")){
            Attack();
        }

        if(isAttack){
            _timer += Time.deltaTime;

            if(_timer >= timeToAttack){
                _timer = 0;
                isAttack = false;
                attackArea.SetActive(isAttack);
            }
        }
    }

    private void Attack(){
        isAttack = true;
        attackArea.SetActive(isAttack);
    }
}
