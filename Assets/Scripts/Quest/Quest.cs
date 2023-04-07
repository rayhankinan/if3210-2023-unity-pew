using UnityEngine;
using System.Linq;
    
public class Quest: MonoBehaviour
{
    public static Objective[] currentObjectives; // TODO: DIBUAT MENJADI PUBLIC UNTUK GUI MELIHAT QUEST

    private Animator _anim;
    
    private void Awake()
    {
        currentObjectives = GetComponents<Objective>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!currentObjectives.All(objective => objective.IsCompleted())) return;

        // TODO: SET TRIGGER UNTUK ANIMASI MEMBERESKAN QUEST
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
