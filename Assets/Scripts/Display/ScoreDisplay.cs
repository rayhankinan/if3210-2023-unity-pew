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
        var currentScore = CurrentStateData.GetCurrentScore();
        var minutes = Mathf.FloorToInt(currentScore / 60);
        var seconds = Mathf.FloorToInt(currentScore % 60);
        
        _text.text = $"{minutes:00}:{seconds:00}";
    }
}
