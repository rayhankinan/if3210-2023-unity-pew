using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static Objective[] objectives;
    
    public float restartDelay = 5f;
    
    private Animator _anim;
    private float _restartTimer;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!objectives.All(objective => objective.IsCompleted())) return;
        
        // TODO: SET TRIGGER UNTUK ANIMASI MEMBERESKAN QUEST
        _restartTimer += Time.deltaTime;

        Debug.Log("WIH QUEST BERHASIL");
        
        if (_restartTimer >= restartDelay)
        {
            // TODO: SET SCENE SELANJUTNYA
        }
    }
}