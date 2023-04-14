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
            playerName.text = CurrentStateData.GetGlobalPlayerName();
            volumeInfo.text = CurrentStateData.GetVolume() + "%";
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
    
    private void ChangeName()
    {
        CurrentStateData.ChangeGlobalPlayerName(playerName.text);
    }
    
    public void VolumeUp()
    {
        CurrentStateData.ChangeVolume(5);
        AudioListener.volume = (float) CurrentStateData.GetVolume() / 100;
        volumeInfo.text = CurrentStateData.GetVolume() + "%";
    }

    public void VolumeDown()
    {
        CurrentStateData.ChangeVolume(-5);
        AudioListener.volume = (float) CurrentStateData.GetVolume() / 100;
        volumeInfo.text = CurrentStateData.GetVolume() + "%";
    }
}