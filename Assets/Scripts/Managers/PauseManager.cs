using UnityEngine;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
	private static bool _isPaused;
	
	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;

	private void Start()
	{
		Time.timeScale = 1;
		_isPaused = false;
	}

	private void Lowpass()
	{
		if (Time.timeScale == 0)
		{
			if (paused != null)
            {
				paused.TransitionTo(.01f);
            }
		}
		else
		{
			if (unpaused != null)
			{
				unpaused?.TransitionTo(.01f);
			}
		}
	}
	
	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		_isPaused = Time.timeScale == 0;
		Lowpass();
	}

	public static void StaticPauseOrUnPause()
    {
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		_isPaused = Time.timeScale == 0;
	}

	public static bool CheckIfPaused()
	{
		return _isPaused;
	}
}
