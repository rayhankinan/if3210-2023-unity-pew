using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void Restart()
    {
        CurrentStateData.LoadData();
        
        SceneManager.LoadScene(CurrentStateData.GetCurrentScene());
    }

    public void MainMenu()
    {
        CurrentStateData.ChangeScene("main_menu");
        
        SceneManager.LoadScene(CurrentStateData.GetCurrentScene());
    }
}