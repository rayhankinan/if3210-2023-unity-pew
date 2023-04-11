using TMPro;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public TMP_InputField playerName;
    public TextMeshProUGUI volumeInfo;

    public void OnToggle()
    {
        mainPanel.SetActive(!mainPanel.activeSelf);
        settingsPanel.SetActive(!settingsPanel.activeSelf);

        if (settingsPanel.activeSelf)
        {
            ShowName();
            ShowVolume();
        }
        else
        {
            ChangeName();
        }
    }

    public void OnClose()
    {
        settingsPanel.SetActive(false);
    }

    private void ShowName()
    {
        playerName.text = CurrentStateData.GetPlayerName();
    }

    public void ChangeName()
    {
        CurrentStateData.ChangeName(playerName.text);
    }

    private void ShowVolume()
    {
        volumeInfo.text = CurrentStateData.GetVolume() + "%";
    }

    public void VolumeUp()
    {
        CurrentStateData.ChangeVolume(5);
        ShowVolume();
    }

    public void VolumeDown()
    {
        CurrentStateData.ChangeVolume(-5);
        ShowVolume();
    }
}