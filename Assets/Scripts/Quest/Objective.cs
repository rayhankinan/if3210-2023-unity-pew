using System;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public GameObject enemy;
    public int amount;
    
    public int currentAmount;

    private void Awake()
    {
        currentAmount = 0;
    }

    public void AddEnemy(GameObject killedEnemy)
    {
        if (enemy.CompareTag(killedEnemy.tag))
        {
            currentAmount = Math.Min(currentAmount + 1, amount);
        }
    }

    public bool IsCompleted()
    {
        return currentAmount == amount;
    }
}