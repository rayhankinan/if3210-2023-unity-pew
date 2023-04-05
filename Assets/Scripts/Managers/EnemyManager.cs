using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    
    [SerializeField]
    private EnemyFactory enemyFactory;
    private IFactory Factory => enemyFactory;

    private void Awake()
    {
        enemyFactory = GetComponent<EnemyFactory>();
    }

    private void Start()
    {
        // Mengeksekusi fungsi Spawn setiap beberapa detik sesui dengan nilai spawnTime
        InvokeRepeating(nameof(Spawn), spawnTime, spawnTime);
    }


    private void Spawn()
    {
        // Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        // Mendapatkan nilai random
        var enemyTag = Random.Range(0, enemyFactory.enemyPrefab.Length);
        var spawnTag = Random.Range(0, spawnPoints.Length);

        // Memduplikasi enemy
        Factory.FactoryMethod(enemyTag, spawnPoints[spawnTag]);
    }
}
