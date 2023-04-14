using UnityEngine;
using UnityEngine.UI;

public class BackManager : MonoBehaviour
{
    private static Image _transitionImage;

    private void Awake()
    {
        _transitionImage = GetComponent<Image>();

        _transitionImage.gameObject.SetActive(false);
    }

    public static void AccessMenu()
    {
        _transitionImage.gameObject.SetActive(true);
    }
}