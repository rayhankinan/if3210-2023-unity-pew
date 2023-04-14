using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    public float reloadTime;

    [SerializeField]
    public Arrows arrowPrefab;

    [SerializeField]
    public Transform spawnPoint;

    private Arrows curArrow;
    private bool isReload;

    public void Reload(){
        if(isReload || curArrow != null) return;
        isReload = true;
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime(){
        yield return new WaitForSeconds(reloadTime);
        curArrow = Instantiate(arrowPrefab, spawnPoint);
        curArrow.transform.localPosition = Vector3.zero;
        isReload = false;
    }

    public void Fire(float firePower){
        if(isReload || curArrow == null) return;
        var force = spawnPoint.TransformDirection(Vector3.forward * firePower);
        curArrow.Fly(force);
        curArrow = null;
        Reload();
    }

    public bool isReady(){
        return (!isReload && curArrow != null);
    }
}
