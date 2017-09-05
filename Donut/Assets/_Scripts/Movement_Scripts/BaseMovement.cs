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
    protected Rigidbody2D m_rigidbody;

    // Info to check if character is on the ground
    // Required for jumping mechanics
    [SerializeField]
    protected Transform m_groundCheck;

    [SerializeField]
    protected LayerMask m_whatIsGround;

    [SerializeField]
    protected float m_groundRadius;

    protected bool m_isGrounded;

    [SerializeField]
    protected float m_moveSpeed;

    [SerializeField]
    protected float m_jumpSpeed;

    // Used to flip character sprite based on which way it's moving
    private bool m_facingRight;

    public bool FacingRight
    {
        set { m_facingRight = value; }
        get { return m_facingRight; }
    }

    public float MoveSpeed
    {
        set { m_moveSpeed = value; }
        get { return m_moveSpeed; }
    }

    public float JumpSpeed
    {
        set { m_jumpSpeed = value; }
        get { return m_jumpSpeed; }
    }

    public void Awake()
    {
        // Always start characters facing right
        m_facingRight = true;
    }

    public virtual void Update()
    {
    }

    public virtual void Start()
    {
        // Get the rigidbody
        m_rigidbody = GetComponent<Rigidbody2D>();

        // Set radius for the ground
        m_groundRadius = 0.3f;
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
        m_facingRight = !m_facingRight;

        Vector2 characterScale = transform.localScale;

        characterScale.x *= -1;

        transform.localScale = characterScale;
    }

    /*
     *  -----------------------private void CheckIsGrounded()------------------
     *  Sets m_isGrounded based on if the player's collider is colliding with the
     *  ground check transform. 
     *  -----------------------------------------------------------------------
     */
    private  void CheckIfGrounded()
    {
        m_isGrounded = Physics2D.OverlapCircle(m_groundCheck.position, m_groundRadius, m_whatIsGround);
    }

    // Each character will have its own move function
    // Playable Characters will have movement based on player input
    // Enemies & NPCs will have AI movement logic in this function
    protected abstract void Move();

}
