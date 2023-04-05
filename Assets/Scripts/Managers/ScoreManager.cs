using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    
    private Text _text;
    
    private void Awake()
    {
        Score = 0;
        _text = GetComponent<Text>();
    }
    
    private void Update()
    {
        _text.text = $"Score: {Score}";
    }
}
