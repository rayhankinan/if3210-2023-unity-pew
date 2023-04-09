using System;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    private static Image _transitionImage;
    private static bool _isOpened;

    private void Awake()
    {
        _transitionImage = GetComponent<Image>();

        _isOpened = false;
        _transitionImage.gameObject.SetActive(_isOpened);
    }

    public static void AccessMenu()
    {
        _isOpened = !_isOpened;
        _transitionImage.gameObject.SetActive(_isOpened);
    }
}