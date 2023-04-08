using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        ScoreGlobal.LoadFromFile();
    }

    private void Awake()
    {
        _text = GetComponent<Text>();
    }
    
    private void Update()
    {
        _text.text = $"Score: {ScoreGlobal.value}";
    }
}
