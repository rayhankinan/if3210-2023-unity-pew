using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }
    
    private void Update()
    {
        _text.text = $"{CurrentStateData.GetCurrentCoin()}";
    }
}