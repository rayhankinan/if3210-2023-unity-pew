using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject scoreboardCanvas;
    public GameObject loadCanvas;
    public GameObject loadPanel;
    
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

        var saveEntries = CurrentStateData.GetSaveEntries();
        var buttons = loadPanel.GetComponentsInChildren<Button>();
        var texts = loadPanel.GetComponentsInChildren<TMP_Text>();

        for (int i = 0; i < saveEntries.Count; i++)
        {
            buttons[i].interactable = true;
            texts[2 * i].text = saveEntries[i].saveName;
            texts[2 * i + 1].text = saveEntries[i].saveDateTime.ToString();
        }
        for (int i = saveEntries.Count; i < 3; i++)
        {
            buttons[i].interactable = false;
            texts[2 * i].text = "(Empty Slot)";
            texts[2 * i + 1].text = "";
        }
    }

    public void CloseLoad()
    {
        mainCanvas.SetActive(true);
        scoreboardCanvas.SetActive(false);
        loadCanvas.SetActive(false);
    }

    public void LoadGame(int index)
    {
        var loaded = CurrentStateData.LoadGameData(index);

        if (!loaded)
        {
            throw new Exception();
        }
        
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
