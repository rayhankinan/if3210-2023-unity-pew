using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{
    [SerializeField]
    public GameObject[] enemyPrefab;
    
    public GameObject FactoryMethod(int enemyTag, Transform spawnPoint)
    {
        var enemy = Instantiate(enemyPrefab[enemyTag], spawnPoint.position, spawnPoint.rotation);
        return enemy;
    }
}