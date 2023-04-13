using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager: MonoBehaviour
{
    private static ObjectiveManager[] _currentObjectives;

    private bool added = false;

    public int rewardCompletion;

    private void Awake()
    {
        _currentObjectives = GetComponents<ObjectiveManager>();
    }

    private void Update()
    {
        if (!_currentObjectives.All(objective => objective.IsCompleted())) return;
        
        if (added == false)
        {
            CurrentStateData.AddCoin(rewardCompletion);
            added = true;
        }
        FinishManager.DisplayButton();
    }

    public static void AddEnemy(GameObject killedEnemy)
    {
        foreach (var currentObjective in _currentObjectives)
            if (!currentObjective.IsCompleted())
            {
                currentObjective.AddEnemy(killedEnemy);
            }
    }

    public static IEnumerable<ObjectiveManager> GetCurrentObjectives()
    {
        return _currentObjectives;
    }
}
