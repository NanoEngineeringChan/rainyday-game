using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles Movement controls for BlueDonut
 */
public class DonutMovement : PlayerMovement
{

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void Move()
    {
        base.Move();

        if ((Input.GetKeyDown(KeyCode.Space)) && (_isGrounded) && (_jumpSpeed > 0))
        {
            StartCoroutine(Jump());
        }
    }

    public IEnumerator Jump()
    {
        _currentCharacter.CharacterAnim.SetBool("IsJumping", true);

        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpSpeed);

        yield return new WaitForSeconds(0.1f);

        _currentCharacter.CharacterAnim.SetBool("IsJumping", false);
    }
}
