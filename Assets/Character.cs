using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction = Vector3.zero;

    [SerializeField] private float speed = 5f;
    private float _tspeed;
    
    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        if (Input.GetKey(KeyCode.LeftShift))
            _tspeed = speed / 2;
        else
            _tspeed = speed;
        _characterController.Move(_direction * (_tspeed * Time.deltaTime));
    }
    
    public void UpdateMovement()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _direction = new Vector3(_input.x, 0, _input.y);
    }
}
