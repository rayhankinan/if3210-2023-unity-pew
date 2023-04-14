using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public GameObject saveFilesPanel;
    public GameObject saveNamePanel;
    public TMP_InputField saveNameInputField;
    private int _slotIndex;
    
    public void OpenSaveFilesPanel()
    {
        saveFilesPanel.SetActive(true);
        saveNamePanel.SetActive(false);
        
        var saveEntries = CurrentStateData.GetSaveEntries();
        var buttons = saveFilesPanel.GetComponentsInChildren<Button>();
        var texts = saveFilesPanel.GetComponentsInChildren<TMP_Text>();

        for (int i = 0; i < 3; i++)
        {
            buttons[i].interactable = true;
            buttons[i].onClick.AddListener(() => OpenSaveNamePanel(i));
            
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

    void OpenSaveNamePanel(int index)
    {
        saveFilesPanel.SetActive(false);
        saveNamePanel.SetActive(true);

        _slotIndex = index;
        saveNameInputField.text = $"Save Slot {index+1}";
    }

    public void OnSave()
    {
        CurrentStateData.SaveGameData(saveNameInputField.text, _slotIndex);
        saveFilesPanel.SetActive(false);
        saveNamePanel.SetActive(false);
        
        // @TODO lanjut ke scene/canvas lain
    }

    public void OnBack()
    {
        saveFilesPanel.SetActive(true);
        saveNamePanel.SetActive(false);
    }
}