using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void Restart()
    {
        SaveManager.OpenSaveFilesPanel();
    }

    public void MainMenu()
    {
        CurrentStateData.ChangeScene("main_menu");
        
        SceneManager.LoadScene(CurrentStateData.GetCurrentScene());
    }
}