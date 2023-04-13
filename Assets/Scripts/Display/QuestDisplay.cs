using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    private Text _text;
    private bool _isComplete;
    
    private void Awake()
    {
        _text = GetComponent<Text>();
        _isComplete = false;
    }

    private void Update()
    {
        _text.text = $"Quest:\n";
        foreach (var objective in QuestManager.GetCurrentObjectives())
        {
            _text.text += $"-. {objective.enemy.tag} ({objective.currentAmount}/{objective.amount})\n";
            if (objective.IsCompleted())
            {
                _isComplete = true;
            }
            else
            {
                _isComplete = false;
            }
        }
        if (_isComplete == true)
        {
            _text.text += $"Quest Complete!\n";
        }
    }
}