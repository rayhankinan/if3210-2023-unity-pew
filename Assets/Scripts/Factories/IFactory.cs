using UnityEngine;

public interface IFactory {
    GameObject FactoryMethod(int enemyTag, Transform spawnPoint);
}