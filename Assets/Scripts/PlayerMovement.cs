using UnityEngine;
using UnityEngine.XR;

/// <summary>
/// A very basic first person player movement script. No bells and whistles added
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    public CharacterController ccontroller;

    [Header("Movement")]
    public float moveSpeed;
    float _horInput;
    float _vertInput;
    Vector3 _moveDirection;

    [Header("Gravity")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    float _g = -9.81f;
    Vector3 _velocity;
    bool _isGrounded;

    //walk animation will be added shortly!
    //[Header("Animation")]
    //public Animator animator;

    private void Start()
    {
        ccontroller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MyInput();
        Move();
    }

    private void Move()
    {
        //check if grounded using a sphere on the character's feet
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        //gravity so our player can fall down the stairs
        _velocity.y += _g * Time.deltaTime;
        ccontroller.Move(_velocity * Time.deltaTime);

        //find direction
        _moveDirection = (transform.forward * _vertInput) + (transform.right * _horInput);

        //using character controller to move
        ccontroller.Move(_moveDirection * moveSpeed * Time.deltaTime);
    }

    /// will most certainly have to remove this for the new input system
    private void MyInput()
    {
        _horInput = Input.GetAxisRaw("Horizontal");
        _vertInput = Input.GetAxisRaw("Vertical");
    }

}
