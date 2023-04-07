using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    private static Objective[] _currentObjectives; // TODO: DIBUAT MENJADI PUBLIC UNTUK GUI MELIHAT QUEST
    
    public float restartDelay = 5f;
    public string nextScene = "main_menu";
    
    private Animator _anim;
    private float _restartTimer;

    private void Awake()
    {
        _currentObjectives = GetComponents<Objective>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_currentObjectives.All(objective => objective.IsCompleted())) return;
        
        // TODO: SET TRIGGER UNTUK ANIMASI MEMBERESKAN QUEST
        _restartTimer += Time.deltaTime;

        if (_restartTimer >= restartDelay)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public static void AddEnemy(GameObject killedEnemy)
    {
        foreach (var currentObjective in _currentObjectives)
            if (!currentObjective.IsCompleted())
            {
                currentObjective.AddEnemy(killedEnemy);
            }
    }
}