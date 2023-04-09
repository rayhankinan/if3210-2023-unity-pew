using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }
    
    private void Update()
    {
        _text.text = $"Score: {CurrentStateData.GetCurrentScore()}";
    }
}
