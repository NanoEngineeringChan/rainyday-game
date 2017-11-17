using System.Collections;
using UnityEngine;

/*
 * Sets structure for generic user based movement
 * 
 */
public class PlayerMovement : BaseMovement
{
    // Reference to the currently active character
    [SerializeField]
    protected PlayableCharacter _currentCharacter;

    private Vector3 _position;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();

        _currentCharacter = FindObjectOfType<PlayableCharacter>();
    }

    public override void Update()
    {
        Move();
	}

    public new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Move()
    {
        LockZPosition();

        if ( (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow) ))
        {
            // Make sure character is facing to the left
            if (FacingRight)
            {
                ChangeCharacterDirection();
            }

            // Move player to the left
            _rigidbody.velocity = new Vector2(-_moveSpeed, 0f);

            // Play characther's walking / running animation
            if (_currentCharacter.CharacterAnim != null)
            {
                _currentCharacter.CharacterAnim.SetBool("IsMoving", true);
            }
        }
        else if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow) ))
        {
            // Make sure character is facing to the right
            if (!FacingRight)
            {
                ChangeCharacterDirection();
            }

            _rigidbody.velocity = new Vector2(_moveSpeed, 0f);

            // Play character's walking / running animation
            if (_currentCharacter.CharacterAnim != null)
            {
                _currentCharacter.CharacterAnim.SetBool("IsMoving", true);
            }
        }
        else
        {
            if (_currentCharacter.CharacterAnim != null)
            {
                _currentCharacter.CharacterAnim.SetBool("IsMoving", false);
            }
        }
    }

    private void LockZPosition()
    {
        // Locks the player's Z position
        // The Z position keeps getting set to zero on start for some reason
        _position = transform.position;
        _position.z = 5f;
        transform.position = _position;
    }
}
