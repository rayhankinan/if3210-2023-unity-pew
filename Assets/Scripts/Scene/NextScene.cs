using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene: MonoBehaviour
{
    public string scene;

    public void NextWithoutSave()
    {
        CurrentStateData.ChangeScene(scene);
        
        SceneManager.LoadScene(CurrentStateData.GetCurrentScene());
    }

    public void NextWithSave()
    {
        CurrentStateData.ChangeScene(scene);
        
        SaveManager.OpenSaveFilesPanel();
    }
}