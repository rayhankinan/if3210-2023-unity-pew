using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private void Update()
    {
        CurrentStateData.AddPlayTime(Time.deltaTime);
    }
}