using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    private static GameObject _background;
    private static GameObject _saveTitle;
    private static GameObject _saveFilesPanel;
    private static GameObject _saveNamePanel;
    private static int _slotIndex;

    public GameObject inputBackground;
    public GameObject inputSaveTitle;
    public GameObject inputSaveFilesPanel;
    public GameObject inputSaveNamePanel;

    public void Awake()
    {
        _background = inputBackground;
        _saveTitle = inputSaveTitle;
        _saveFilesPanel = inputSaveFilesPanel;
        _saveNamePanel = inputSaveNamePanel;
        
        _background.SetActive(false);
        _saveTitle.SetActive(false);
        _saveFilesPanel.SetActive(false);
        _saveNamePanel.SetActive(false);
    }

    public static void OpenSaveFilesPanel()
    {
        _background.SetActive(true);
        _saveTitle.SetActive(true);
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
        _saveTitle.SetActive(false);
        _saveFilesPanel.SetActive(false);
        _saveNamePanel.SetActive(true);

        _slotIndex = index;
        InputManager.SetText($"Save Slot {index+1}");
    }

    public static int GetCurrentSlotIndex()
    {
        return _slotIndex;
    }

    public static void OnSave()
    {
        _saveTitle.SetActive(false);
        _saveFilesPanel.SetActive(false);
        _saveNamePanel.SetActive(false);
    }

    public static void OnBack()
    {
        _saveTitle.SetActive(true);
        _saveFilesPanel.SetActive(true);
        _saveNamePanel.SetActive(false);
    }
}