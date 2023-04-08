using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// TODO: BISA DITAMBAHKAN ANIMATOR ISPAUSED
public class PauseManager : MonoBehaviour
{
	public static bool isPaused;
	
	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;

	private void Start()
	{
		isPaused = false;
	}
	
	private void Update()
	{
		if (!Input.GetKeyDown(KeyCode.Escape)) return;
		Pause();
	}

	private void Lowpass()
	{
		if (Time.timeScale == 0)
		{
			paused.TransitionTo(.01f);
		}
		else
		{
			unpaused.TransitionTo(.01f);
		}
	}
	
	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		isPaused = Time.timeScale == 0;
		Lowpass();
	}
	
	public void Quit()
	{
		SceneManager.LoadScene("main_menu");
	}
}
