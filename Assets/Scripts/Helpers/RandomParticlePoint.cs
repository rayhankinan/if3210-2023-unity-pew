using UnityEngine;

public class RandomParticlePoint : MonoBehaviour 
{
    [Range(0f, 1f)]
    public float normalizedTime;
    
    private void OnValidate()
    {
        GetComponent<ParticleSystem>().Simulate(normalizedTime, true, true);
    }
}
