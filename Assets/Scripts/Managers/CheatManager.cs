using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheatManager : MonoBehaviour
{
    //private PauseManager pauseManager;
    
    [Header("UI Components")]
    public Canvas consoleCanvas;
    public ScrollRect scrollRect;
    public TMP_Text consoleText;
    public TMP_Text inputText;
    public TMP_InputField consoleInput;
    
    void Start()
    {
        consoleCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            consoleCanvas.gameObject.SetActive(!consoleCanvas.gameObject.activeInHierarchy);
            //pauseManager.Pause();
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
        
        if (consoleCanvas.gameObject.activeInHierarchy)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (inputText.text != "")
                {
                    AddMessageToConsole(inputText.text);
                    AddMessageToConsole("Command not recognized.");
                }
            }
        }
    }
    
    private void AddMessageToConsole(string msg)
    {
        consoleText.text += msg + "\n";
        //scrollRect.verticalNormalizedPosition = 0f;
    }
}
