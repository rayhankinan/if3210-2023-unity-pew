using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager: MonoBehaviour
{
    private static ObjectiveManager[] _currentObjectives;
    
    public int rewardCompletion;
    private bool _added;

    private void Awake()
    {
        _currentObjectives = GetComponents<ObjectiveManager>();
    }

    private void Update()
    {
        if (!IsQuestCompleted()) return;
        
        if (_added == false)
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            EnemyManager.KillAllEnemy();
            
            _added = true;
            
            CurrentStateData.AddCoin(rewardCompletion);
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

    public static bool IsQuestCompleted()
    {
        return _currentObjectives.All(objective => objective.IsCompleted());
    }
}
