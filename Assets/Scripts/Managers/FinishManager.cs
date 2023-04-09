using UnityEngine;
using UnityEngine.UI;

public class FinishManager : MonoBehaviour
{
    private static Button _nextButton;

    private void Awake()
    {
        _nextButton = GetComponent<Button>();
        
        _nextButton.gameObject.SetActive(false);
    }

    public void OpenMenu()
    {
        TransitionManager.AccessMenu();
    }

    public static void DisplayButton()
    {
        _nextButton.gameObject.SetActive(true);
    }
}