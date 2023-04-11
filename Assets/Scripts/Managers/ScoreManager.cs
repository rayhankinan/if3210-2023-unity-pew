using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private void Update()
    {
        CurrentStateData.AddScore(Time.deltaTime);
    }
}