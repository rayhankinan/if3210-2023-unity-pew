using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject scoreboardCanvas;
    public GameObject loadCanvas;
    
    // Start is called before the first frame update
    private void Start()
    {
        CurrentStateData.LoadData();
        AudioListener.volume = (float) CurrentStateData.GetVolume() / 100;
        
        mainCanvas.SetActive(true);
        scoreboardCanvas.SetActive(false);
        loadCanvas.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("level_01");
    }

    public void OpenLoad()
    {
        mainCanvas.SetActive(false);
        scoreboardCanvas.SetActive(false);
        loadCanvas.SetActive(true);
    }

    public void LoadGame(int index)
    {
        CurrentStateData.LoadGameData(index);
        SceneManager.LoadScene(CurrentStateData.GetCurrentScene());
    }
    
    public void QuitGame()
    {
        CurrentStateData.SaveData();
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
        loadCanvas.SetActive(false);
    }

    public void CloseScoreboard()
    {
        mainCanvas.SetActive(true);
        scoreboardCanvas.SetActive(false);
        loadCanvas.SetActive(false);
    }
}
