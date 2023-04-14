using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    private static GameObject _saveFilesPanel;
    private static GameObject _saveNamePanel;
    private static TMP_InputField _saveNameInputField;
    private static int _slotIndex;
    
    public GameObject saveFilesPanel;
    public GameObject saveNamePanel;
    public TMP_InputField saveNameInputField;

    public void Awake()
    {
        _saveFilesPanel = saveFilesPanel;
        _saveNamePanel = saveNamePanel;
        _saveNameInputField = saveNameInputField;
        
        _saveFilesPanel.SetActive(false);
        _saveNamePanel.SetActive(false);
    }

    public static void OpenSaveFilesPanel()
    {
        _saveFilesPanel.SetActive(true);
        _saveNamePanel.SetActive(false);
        
        var saveEntries = CurrentStateData.GetSaveEntries();
        var buttons = _saveFilesPanel.GetComponentsInChildren<Button>();
        var texts = _saveFilesPanel.GetComponentsInChildren<TMP_Text>();

        for (var i = 0; i < 3; i++)
        {
            buttons[i].interactable = true;
            
            var i1 = i;
            buttons[i].onClick.AddListener(() => OpenSaveNamePanel(i1));
            
            if (saveEntries != null)
            {
                texts[2 * i].text = saveEntries[i].saveName;
                texts[2 * i + 1].text = saveEntries[i].saveDateTime.ToString();
            }
            else
            {
                texts[2 * i].text = "(Empty Slot)";
                texts[2 * i + 1].text = "";
            }
        }
    }

    private static void OpenSaveNamePanel(int index)
    {
        _saveFilesPanel.SetActive(false);
        _saveNamePanel.SetActive(true);

        _slotIndex = index;
        _saveNameInputField.text = $"Save Slot {index+1}";
    }

    public void OnSave()
    {
        CurrentStateData.SaveGameData(_saveNameInputField.text, _slotIndex);
        _saveFilesPanel.SetActive(false);
        _saveNamePanel.SetActive(false);
        
        SceneManager.LoadScene(CurrentStateData.GetCurrentScene());
    }

    public void OnBack()
    {
        _saveFilesPanel.SetActive(true);
        _saveNamePanel.SetActive(false);
    }
}