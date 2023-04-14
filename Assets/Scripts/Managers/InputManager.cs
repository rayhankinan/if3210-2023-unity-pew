using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    private static TMP_InputField _saveNameInputField;

    private void Awake()
    {
        _saveNameInputField = GetComponent<TMP_InputField>();
    }

    public static void SetText(string text)
    {
        _saveNameInputField.text = text;
    }

    public static string GetText()
    {
        return _saveNameInputField.text;
    }
}