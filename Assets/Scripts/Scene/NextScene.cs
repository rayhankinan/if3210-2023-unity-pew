using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class NextScene: MonoBehaviour
{
    public string scene;

    public void NextWithoutSave()
    {
        SceneManager.LoadScene("cutscene_shopkeeper_turun");
        CurrentStateData.ChangeScene(scene);
    }

    public void NextWithSave()
    {
        CurrentStateData.ChangeScene(scene);
        SaveManager.OpenSaveFilesPanel();
    }

    public void NextWithoutShopkeeper()
    {
        CurrentStateData.ChangeScene(scene);
        SceneManager.LoadScene(scene);
    }
}