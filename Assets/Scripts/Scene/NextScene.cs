using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene: MonoBehaviour
{
    public string scene;

    public void NextWithoutSave()
    {
        CurrentStateData.ChangeScene(scene);
        SceneManager.LoadScene("cutscene_shopkeeper_turun");
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