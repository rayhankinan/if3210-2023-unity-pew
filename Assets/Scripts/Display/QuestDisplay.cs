using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    private Text _text;
    
    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = $"Quest:\n";
        foreach (var objective in QuestManager.GetCurrentObjectives())
        {
            _text.text += $"-. {objective.enemy.tag} ({objective.currentAmount}/{objective.amount})\n";
        }
        
        if (QuestManager.IsQuestCompleted())
        {
            _text.text += $"Quest Complete!\n";
        }
    }
}