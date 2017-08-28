using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*---------------public class PlayerController--------------
 * Handles basic player movement, and user input For now, 
 * simply handles moving left and right, and jumping
 * ----------------------------------------------------------
 */
[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Animator m_animator; // NOTE: Might move animator in order to encapsulate animations????
    private Rigidbody2D m_rigidbody;

    [SerializeField]
    private Transform m_groundCheck;

    [SerializeField]
    private LayerMask m_whatisGround;

    [SerializeField]
    private float m_playerSpeed;

    [SerializeField]
    private float m_jumpSpeed;

    private float m_groundRadius;

    [SerializeField]
    private bool m_facingRight;

    private bool m_isGrounded;

    public float PlayerSpeed
    {
        get { return m_playerSpeed; }
        set { m_playerSpeed = value; }
    }

    public float JumpSpeed
    {
        get { return m_jumpSpeed; }
        set { m_jumpSpeed = value; }
    }

    public bool FacingRight
    {
        get { return m_facingRight; }
        set { m_facingRight = value; }
    }

    private void Awake()
    {
        m_facingRight = true;
    }

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();

        m_groundRadius = .3f;
    }

    public void InitializePlayerMovement(float playerSpeed, float jumpSpeed, Animator characterAnim)
    {
        PlayerSpeed = playerSpeed;
        JumpSpeed = jumpSpeed;

        m_animator = characterAnim;
    }

    private void FixedUpdate()
    {
        // Do this in fixed update because it's physics based
        CheckIsGrounded();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Flip the sprite the right way, then give it velocity in that direction
        // Facing left is negative playerSpeed, and facing right is positive playerSpeed
        if (Input.GetKey(KeyCode.A))
        {
            if (m_facingRight)
            {
                ChangeCharacterDirection();
            }

            m_rigidbody.velocity = new Vector2(-m_playerSpeed, m_rigidbody.velocity.y);
            m_animator.SetBool("IsMoving", true);
        }


        else if (Input.GetKey(KeyCode.D))
        {
            if (!m_facingRight)
            {
                ChangeCharacterDirection();
            }

            m_rigidbody.velocity = new Vector2(m_playerSpeed, m_rigidbody.velocity.y);
            m_animator.SetBool("IsMoving", true);
        }
        else
        {
            // If there's no input, switch to idle animation
            m_animator.SetBool("IsMoving", false);
        }

        // Player can only jump if the sprite is on the ground, and is able to jump
        // (Characters with jumpSpeed of 0 can't jump)
        if (Input.GetKey(KeyCode.Space) && m_isGrounded && m_jumpSpeed > 0)
        {
            StartCoroutine(Jump());
        }
    }

    /*
     * ---------------------- public void FlipPlayer()--------------------------
     * Flips the player sprite on its x-axis based on which direction it's facing
     * --------------------------------------------------------------------------
     */
    public void ChangeCharacterDirection()
    {
        m_facingRight = !m_facingRight;

        Vector2 playerScale = transform.localScale;

        playerScale.x *= -1;

        transform.localScale = playerScale;
    }

    /*
     * -----------------------private IEnumerator Jump()--------------------------
     * Allows the player to Jump by giving it velocity on the y-axis
     * Plays the PlayerJump animation on the way up, waits for .02 seconds, 
     * then plays the falling animation on the way back down
     * 
     * NOTE: May have to change Jump functionality if we want different characters
     *       to have different jump heights / jump capabilities
     * ---------------------------------------------------------------------------
     */
    private IEnumerator Jump()
    {
        m_animator.SetBool("IsJumping", true);
        m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_jumpSpeed);

        yield return new WaitForSeconds(.1f);

        m_animator.SetBool("IsJumping", false);
    }

    /*
     *  -----------------------private void CheckIsGrounded()------------------
     *  Sets m_isGrounded based on if the player's collider is colliding with the
     *  ground check transform. 
     *  -----------------------------------------------------------------------
     */
    private void CheckIsGrounded()
    {
        m_isGrounded = Physics2D.OverlapCircle(m_groundCheck.position, m_groundRadius, m_whatisGround);
    }
}

