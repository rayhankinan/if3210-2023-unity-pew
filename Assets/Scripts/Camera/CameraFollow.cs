using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    private Vector3 _offset;
    
    private void Start()
    {
        // Mendapatkan offset antara target dan camera
        _offset = transform.position - target.position;
    }
    
    private void FixedUpdate()
    {
        // Mendapatkan posisi untuk camera
        var targetCamPos = target.position + _offset;
        
        // Set posisi camera dengan smoothing
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}