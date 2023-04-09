using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene: MonoBehaviour
{
    public string scene;

    public void NextWithoutSave()
    {
        SceneGlobal.ChangeScene(scene);
        
        SceneManager.LoadScene(SceneGlobal.GetCurrentValue());
    }

    public void NextWithSave()
    {
        SceneGlobal.ChangeScene(scene);
        
        // CoinGlobal.SaveToFile();
        // ScoreGlobal.SaveToFile();
        // SceneGlobal.SaveToFile();

        SceneManager.LoadScene(SceneGlobal.GetCurrentValue());
    }
}