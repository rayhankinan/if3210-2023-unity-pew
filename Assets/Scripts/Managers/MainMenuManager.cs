using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start ()
    {
        CurrentStateData.LoadData ();
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
}
