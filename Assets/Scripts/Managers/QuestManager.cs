using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static Objective[] currentObjectives; // TODO: DIGUNAKAN PADA GUI UNTUK MELIHAT PROGRESS QUEST
    
    public float restartDelay = 5f;
    
    private Animator _anim;
    private float _restartTimer;

    private void Awake()
    {
        currentObjectives = GetComponents<Objective>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!currentObjectives.All(objective => objective.IsCompleted())) return;
        
        // TODO: SET TRIGGER UNTUK ANIMASI MEMBERESKAN QUEST
        _restartTimer += Time.deltaTime;

        if (_restartTimer >= restartDelay)
        {
            SceneManager.LoadScene("main_menu");
        }
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