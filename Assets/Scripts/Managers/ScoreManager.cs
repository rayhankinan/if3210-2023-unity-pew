using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    
    private Text _text;
    
    private void Awake()
    {
        score = 0;
        _text = GetComponent<Text>();
    }
    
    private void Update()
    {
        _text.text = $"Score: {score}";
    }
}
