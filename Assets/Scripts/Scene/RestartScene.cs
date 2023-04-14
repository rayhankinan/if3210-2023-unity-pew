using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void Restart()
    {
        var loaded = CurrentStateData.LoadGameData(CurrentIndexData.GetIndex());

        if (!loaded)
        {
            throw new Exception();
        }
        
        SceneManager.LoadScene(CurrentStateData.GetCurrentScene());
    }

    public void MainMenu()
    {
        CurrentStateData.ChangeScene("main_menu");
        
        SceneManager.LoadScene(CurrentStateData.GetCurrentScene());
    }
}