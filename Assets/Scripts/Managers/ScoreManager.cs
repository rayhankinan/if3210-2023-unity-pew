using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject shopKeeper;

    private void Update()
    {
        if (!shopKeeper.activeSelf)
        {
            CurrentStateData.AddPlayTime(Time.deltaTime);
        }
    }
}