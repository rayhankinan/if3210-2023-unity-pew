using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float reloadTime;

    [SerializeField] private Arrows arrowPrefab;

    [SerializeField] private Transform spawnPoint;

    private Arrows curArrow;

    private bool isReloading;

    public void Start()
    {
        Time.timeScale = 1;
    }
    public void Reload()
    {
        if (isReloading || curArrow != null) return;
        isReloading = true; 
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        curArrow = Instantiate(arrowPrefab, spawnPoint);
        curArrow.transform.localPosition = Vector3.zero;
        isReloading = false;
    }

    public void Fire(float firePower)
    {
        if (isReloading || curArrow == null) return;
        var force = spawnPoint.TransformDirection(Vector3.down * firePower);
        curArrow.Fly(force, firePower);
        var light = curArrow.GetComponent<Light>();
        light.enabled = true;
        curArrow = null;
        Reload();
    }

    public bool IsReady()
    {
        return (!isReloading && curArrow != null);
    }
}
