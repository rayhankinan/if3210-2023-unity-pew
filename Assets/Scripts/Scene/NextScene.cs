using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene: MonoBehaviour
{
    public string scene;

    public void NextWithoutSave()
    {
        if (CurrentStateData.GetCurrentScene() != "level_04")
        {
            SceneManager.LoadScene("cutscene_shopkeeper_turun");
        }
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