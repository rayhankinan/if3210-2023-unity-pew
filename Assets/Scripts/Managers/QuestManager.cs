using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private Text _text;
    
    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = $"Quest:\n";
        
        foreach (var objective in Quest.currentObjectives)
        {
            _text.text += $"-. {objective.enemy.tag} ({objective.currentAmount}/{objective.amount})\n";
        }
    }
}