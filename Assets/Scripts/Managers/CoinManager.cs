using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static int coin;
    
    private Text _text;
    
    private void Awake()
    {
        coin = 0;
        _text = GetComponent<Text>();
    }
    
    private void Update()
    {
        _text.text = $"{coin}";
    }
}