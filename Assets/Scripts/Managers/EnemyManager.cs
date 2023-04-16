using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

struct RandomSelection
{
    private readonly int _value;
    private readonly float _probability;

    public RandomSelection(int value, float probability) {
        _value = value;
        _probability = probability;
    }

    public int GetValue() {
        return _value;
    }

    public float GetProbability() {
        return _probability;
    }
}

public class EnemyManager : MonoBehaviour
{
    private static readonly List<GameObject> ListOfEnemy = new();
    
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public GameObject shopKeeper;

    private EnemyFactory _enemyFactory;
    private IFactory Factory => _enemyFactory;
    private bool _isWizardSpawned;

    private static int GetRandomValue(params RandomSelection[] selections)
    {
        var rand = Random.value;
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

    public static void RemoveEnemy(GameObject enemy)
    {
        ListOfEnemy.Remove(enemy);
    }

    public static void KillAllEnemy()
    {
        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        foreach (var enemyHealth in ListOfEnemy.Select(enemy => enemy.GetComponent<EnemyHealth>()).ToList())
        {
            enemyHealth.Kill();
        }
    }
    
    private void Awake()
    {
        _enemyFactory = GetComponent<EnemyFactory>();
        _isWizardSpawned = false;
    }

    private void Start()
    {
        // Mengeksekusi fungsi Spawn setiap beberapa detik sesui dengan nilai spawnTime
        if (CurrentStateData.GetCurrentScene() == "level_04")
        {
            InvokeRepeating(nameof(SpawnWizard), 60, spawnTime);
        }
        InvokeRepeating(nameof(Spawn), spawnTime, spawnTime);
    }

    private void Spawn()
    {
        // Jika player telah mati atau quest sudah beres maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f || QuestManager.IsQuestCompleted() || shopKeeper.activeSelf)
        {
            return;
        }

        // Mendapatkan nilai random
        var enemyTag = _enemyFactory.enemyPrefab.Length switch
        {
            1 => 0,
            2 => GetRandomValue(new RandomSelection(0, .6f), new RandomSelection(1, .4f)),
            _ => GetRandomValue(new RandomSelection(0, .4f), new RandomSelection(1, .35f), new RandomSelection(2, .25f))
        };

        var spawnTag = Random.Range(0, spawnPoints.Length);

        // Menduplikasi enemy
        var newEnemy = Factory.FactoryMethod(enemyTag, spawnPoints[spawnTag]);
        
        ListOfEnemy.Add(newEnemy);
    }

    private void SpawnWizard()
    {
        if (playerHealth.currentHealth <= 0f || QuestManager.IsQuestCompleted() || shopKeeper.activeSelf || _isWizardSpawned)
        {
            return;
        }

        var wizard = Factory.FactoryMethod(3, spawnPoints[0]);
        _isWizardSpawned = true;
        
        ListOfEnemy.Add(wizard);
    }
}
