using System;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public GameObject enemy;
    public int amount;

    private int _currentAmount;

    private void Awake()
    {
        _currentAmount = 0;
    }

    public void AddEnemy(GameObject killedEnemy)
    {
        if (ReferenceEquals(enemy, killedEnemy))
        {
            _currentAmount = Math.Min(_currentAmount + 1, amount);
        }
    }

    public bool IsCompleted()
    {
        return _currentAmount == amount;
    }
}