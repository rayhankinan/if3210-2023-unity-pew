using UnityEngine;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

// TODO: BISA DITAMBAHKAN ANIMATOR ISPAUSED
public class PauseManager : MonoBehaviour {
	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;

	private void Start()
	{

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
		Lowpass();
	}
	
	public void Quit()
	{
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}
