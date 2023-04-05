using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private const float CamRayLength = 100f;
    
    public float speed = 6f;
    private Vector3 _movement;
    private Animator _anim;
    private Rigidbody _playerRigidbody;
    private int _floorMask;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        // Mendapatkan nilai mask dari layer yang bernama Floor
        _floorMask = LayerMask.GetMask("Floor");
        
        // Mendapatkan komponen Animator
        _anim = GetComponent<Animator>();
        
        // Mendapatkan komponen Rigidbody
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Turning()
    {
        // Buat Ray dari posisi mouse di layar
        var camRay = _camera.ScreenPointToRay(Input.mousePosition);

        // Cek Raycast
        if (!Physics.Raycast(camRay, out var floorHit, CamRayLength, _floorMask)) return;
        
        // Mendapatkan vector dari posisi player dan posisi floorHit
        var playerToMouse = floorHit.point - transform.position;
        playerToMouse.y = 0f;
            
        // Mendapatkan look rotation baru ke hit position
        var newRotation = Quaternion.LookRotation(playerToMouse);
            
        // Rotasi player
        _playerRigidbody.MoveRotation(newRotation);
    }

    private void FixedUpdate()
    {
        // Mendapatkan nilai input horizontal (-1,0,1)
        var h = Input.GetAxisRaw("Horizontal");
        
        // Mendapatkan nilai input vertical (-1,0,1)
        var v = Input.GetAxisRaw("Vertical");
        
        Move(h, v);
        Turning();
        Animating(h, v);
    }
    
    // Method player dapat berjalan
    public void Move(float h, float v)
    {
        // Set nilai x dan y
        _movement.Set(h, 0f, v);
        
        // Menormalisasi nilai vector agar total panjang dari vector adalah 1
        _movement = _movement.normalized * (speed * Time.deltaTime);
        
        // Move to position
        _playerRigidbody.MovePosition(transform.position + _movement);
    }
    
    public void Animating(float h, float v)
    {
        var walking = h != 0f || v != 0f;
        _anim.SetBool(IsWalking, walking);
    }
}
