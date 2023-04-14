using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private static readonly int GameOver = Animator.StringToHash("GameOver");
    
    public PlayerHealth playerHealth;
    public float waitMenuDelay = 3f;
    public float restartDelay = 8f;
    
    private Animator _anim;
    private float _restartTimer;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerHealth.currentHealth > 0) return;

        _anim.SetTrigger(GameOver);
        _restartTimer += Time.deltaTime;

        if (_restartTimer >= waitMenuDelay)
        {
            BackManager.AccessMenu();
        }

        if (_restartTimer >= restartDelay)
        {
            SceneManager.LoadScene("main_menu");
        }
    }
}