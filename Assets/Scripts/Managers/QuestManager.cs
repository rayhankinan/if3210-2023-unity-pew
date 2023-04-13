using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager: MonoBehaviour
{
    private static ObjectiveManager[] _currentObjectives;

    private void Awake()
    {
        _currentObjectives = GetComponents<ObjectiveManager>();
    }

    private void Update()
    {
        if (!_currentObjectives.All(objective => objective.IsCompleted())) return;

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
