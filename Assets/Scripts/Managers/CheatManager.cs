using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class CheatCommandBase
{
    public abstract string commandID { get; protected set; }
    public abstract string commandDescription { get; protected set; }
    public string commandFormat { get; protected set; }

    public void AddCommandToConsole()
    {
        CheatManager.AddCommandsToConsole(commandID, this);
    }
    public abstract void RunCommand();
}

public class CheatManager : MonoBehaviour
{
    public static CheatManager Instance { get; private set; }
    public static Dictionary<string, CheatCommandBase> Commands { get; private set; }
    
    [Header("UI Components")]
    public Canvas consoleCanvas;
    public TMP_Text consoleText;
    public TMP_Text inputText;
    public TMP_InputField consoleInput;
    
    public void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        
        Instance = this; 
        Commands = new Dictionary<string, CheatCommandBase>();
    }

    private void CreateCommands()
    {
        
    }
    
    void Start()
    {
        consoleCanvas.gameObject.SetActive(false);
        CreateCommands();
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

    public static void AddCommandsToConsole(string _name, CheatCommandBase _command)
    {
        if (!Commands.ContainsKey(_name))
        {
            Commands.Add(_name, _command);
        }
    }
    
    private void AddMessageToConsole(string msg)
    {
        consoleText.text += msg + "\n";
    }
}
