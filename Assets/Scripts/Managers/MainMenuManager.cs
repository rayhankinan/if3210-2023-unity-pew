using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    
    // Update is called once per frame
    private void Update()
    {
        
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("level_01");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
