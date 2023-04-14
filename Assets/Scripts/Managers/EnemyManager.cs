using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    

    private EnemyFactory _enemyFactory;
    private IFactory Factory => _enemyFactory;

    private void Awake()
    {
        _enemyFactory = GetComponent<EnemyFactory>();
    }

    private void Start()
    {
        // Mengeksekusi fungsi Spawn setiap beberapa detik sesui dengan nilai spawnTime
        InvokeRepeating(nameof(Spawn), spawnTime, spawnTime);
        if (CurrentStateData.GetCurrentScene() == "level_04")
        {
            Invoke(nameof(SpawnWizard), spawnTime);
        }
    }
    
    private void Spawn()
    {
        // Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        // Mendapatkan nilai random
        var enemyTag = 0;
        switch (_enemyFactory.enemyPrefab.Length)
        {
            case 1:
                enemyTag = 0;
                break;
            case 2:
                enemyTag = GetRandomValue(
                    new RandomSelection(0, .6f),
                    new RandomSelection(1, .4f)
                );
                break;
            default:
                enemyTag = GetRandomValue(
                    new RandomSelection(0, .4f),
                    new RandomSelection(1, .35f),
                    new RandomSelection(2, .25f)
                );
                break;
        }
    
        var spawnTag = Random.Range(0, spawnPoints.Length);

        // Menduplikasi enemy
        Factory.FactoryMethod(enemyTag, spawnPoints[spawnTag]);
    }

    private void SpawnWizard()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        var enemyTag = 3;

        Factory.FactoryMethod(enemyTag, spawnPoints[0]);
    }

    private struct RandomSelection
    {
        private int value;
        private float probability;

        public RandomSelection(int value, float probability) {
            this.value = value;
            this.probability = probability;
        }

        public int GetValue() {
            return this.value;
        }

        public float GetProbability() {
            return this.probability;
        }
    }

    private int GetRandomValue(params RandomSelection[] selections)
    {
        float rand = Random.value;
        float currentProb = 0;
        foreach (var selection in selections)
        {
            currentProb += selection.GetProbability();
            if (rand <= currentProb)
            {
                return selection.GetValue();
            }
        }

        return -1;
    }
}
