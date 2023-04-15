using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopkeeperSceneManager : MonoBehaviour
{
    public float timeLimit;
    float _startTime;

    void Start()
    {
        Time.timeScale = 1;
        _startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - _startTime > timeLimit)
        {
            var nextScene = CurrentStateData.GetCurrentScene();
            SceneManager.LoadScene(nextScene);
        }
    }
}