using UnityEngine;

/*
 * class BaseMovement
 * 
 * Sets the framework for characters to move. Each character will 
 * have some sort of movement script attached to it whether the character
 * is playable or an NPC. All movement will be done in the abstract function 
 * called 'Move'. 
 */
[System.Serializable]
public abstract class BaseMovement : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    // Info to check if character is on the ground
    // Required for jumping mechanics
    [SerializeField]
    protected Transform _groundCheck;

    [SerializeField]
    protected LayerMask _whatIsGround;

    [SerializeField]
    protected float _groundRadius;

    protected bool _isGrounded;

    [SerializeField]
    protected float _moveSpeed;

    [SerializeField]
    protected float _jumpSpeed;


    // Used to flip character sprite based on which way it's moving
    [SerializeField]
    private bool _facingRight;

    public bool FacingRight
    {
        set { _facingRight = value; }
        get { return _facingRight; }
    }

    public float MoveSpeed
    {
        set { _moveSpeed = value; }
        get { return _moveSpeed; }
    }

    public float JumpSpeed
    {
        set { _jumpSpeed = value; }
        get { return _jumpSpeed; }
    }

    public virtual void Awake()
    {
//        FacingRight = true;
    }


    public virtual void Update()
    {
    }

    public void InitializeMovement(float moveSpeed, float jumpSpeed)
    {
        _moveSpeed = moveSpeed;
        _jumpSpeed = jumpSpeed;
    }

    public virtual void Start()
    {
        // Get the rigidbody
        _rigidbody = GetComponent<Rigidbody2D>();

        // Set radius for the ground
        _groundRadius = 0.3f;
    }

    public void FixedUpdate()
    {
        // Keep checking if the character is on the ground.
        // This is called in FixedUpdate because it is a physics based check
        CheckIfGrounded();
    }

    /*
     * ---------------------- public void ChangeDirection()--------------------------
     * Flips the player sprite on its x-axis based on which direction it's facing
     * --------------------------------------------------------------------------
     */

    public void ChangeCharacterDirection()
    {
        FacingRight = !FacingRight;

        Vector2 characterScale = transform.localScale;

        characterScale.x *= -1;

        transform.localScale = characterScale;
    }

    /*
     *  -----------------------private void CheckIsGrounded()------------------
     *  Sets _isGrounded based on if the player's collider is colliding with the
     *  ground check transform. 
     *  -----------------------------------------------------------------------
     */
    private  void CheckIfGrounded()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _whatIsGround);
    }

    // Each character will have its own move function
    // Playable Characters will have movement based on player input
    // Enemies & NPCs will have AI movement logic in this function
    protected abstract void Move();

}
