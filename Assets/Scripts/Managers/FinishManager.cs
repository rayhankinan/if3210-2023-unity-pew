using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    public static Button nextButton;
    
    public string nextScene;

    private void Awake()
    {
        nextButton = GetComponent<Button>();
        
        nextButton.gameObject.SetActive(false);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}