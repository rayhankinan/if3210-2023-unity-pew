using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveState : MonoBehaviour
{
    public void Save()
    {
        InputManager.GetText();
        CurrentStateData.SaveGameData(InputManager.GetText(), SaveManager.GetCurrentSlotIndex());
        SaveManager.OnSave();

        SceneManager.LoadScene("cutscene_shopkeeper_turun");
    }

    public void Back()
    {
        SaveManager.OnBack();
    }
}