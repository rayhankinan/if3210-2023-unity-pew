using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject scoreboardCanvas;
    
    // Start is called before the first frame update
    private void Start()
    {
        CurrentStateData.LoadData();
        AudioListener.volume = (float) CurrentStateData.GetVolume() / 100;
        
        mainCanvas.SetActive(true);
        scoreboardCanvas.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(CurrentStateData.GetCurrentScene());
    }
    
    public void QuitGame()
    {
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else 
		Application.Quit();
        #endif
    }

    public void OpenScoreboard()
    {
        mainCanvas.SetActive(false);
        scoreboardCanvas.SetActive(true);
    }

    public void CloseScoreboard()
    {
        mainCanvas.SetActive(true);
        scoreboardCanvas.SetActive(false);
    }
}
