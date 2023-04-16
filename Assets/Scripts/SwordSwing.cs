using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{

    public GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton($"Fire1"))
        {
            StartCoroutine(SwordSwinging());
        }
    }

    IEnumerator SwordSwinging()
    {
        sword.GetComponent<Animator>().Play("SwordSwing");
        Debug.Log("masuk");
        yield return new WaitForSecondsRealtime(1.0f);
        sword.GetComponent<Animator>().Play("New State");
    }
}