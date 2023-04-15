using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class NextScene: MonoBehaviour
{
    public Animator anim;
    public string scene;

    public void NextWithoutSave()
    {
        if (CurrentStateData.GetCurrentScene() != "level_04")
        {
            StartCoroutine(Crossfade());
            SceneManager.LoadScene("cutscene_shopkeeper_turun");
        }
        CurrentStateData.ChangeScene(scene);
        StartCoroutine(Crossfade());
    }

    public void NextWithSave()
    {
        CurrentStateData.ChangeScene(scene);
        SaveManager.OpenSaveFilesPanel();
    }

    public void NextWithoutShopkeeper()
    {
        CurrentStateData.ChangeScene(scene);
        StartCoroutine(Crossfade());
        SceneManager.LoadScene(scene);
    }

    IEnumerator Crossfade()
    {
        Debug.Log("Start");
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
    }
}