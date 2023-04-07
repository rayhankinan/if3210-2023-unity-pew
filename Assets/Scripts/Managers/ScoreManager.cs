using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text _text;
    
    private void Awake()
    {
        ScoreGlobal.LoadFromFile();
        _text = GetComponent<Text>();
    }
    
    private void Update()
    {
        _text.text = $"Score: {ScoreGlobal.value}";
    }
}
