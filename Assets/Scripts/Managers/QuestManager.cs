using System.Linq;
using UnityEngine;

public class QuestManager: MonoBehaviour
{
    public static ObjectiveManager[] currentObjectives;

    private void Awake()
    {
        currentObjectives = GetComponents<ObjectiveManager>();
    }

    private void Update()
    {
        if (!currentObjectives.All(objective => objective.IsCompleted())) return;

        FinishManager.nextButton.gameObject.SetActive(true);
    }

    public static void AddEnemy(GameObject killedEnemy)
    {
        foreach (var currentObjective in currentObjectives)
            if (!currentObjective.IsCompleted())
            {
                currentObjective.AddEnemy(killedEnemy);
            }
    }
}
