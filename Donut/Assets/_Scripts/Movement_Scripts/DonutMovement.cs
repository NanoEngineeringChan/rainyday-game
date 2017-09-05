using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles Movement controls for BlueDonut
 */
public class DonutMovement : PlayerMovement
{
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

        if ( (Input.GetKeyDown(KeyCode.Space)) && (m_isGrounded) && (m_jumpSpeed > 0) )
        {
            StartCoroutine(Jump());
        }
    }

    public IEnumerator Jump()
    {
        m_player.CharacterAnim.SetBool("IsJumping", true);

        m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_jumpSpeed);

        yield return new WaitForSeconds(0.1f);

        m_player.CharacterAnim.SetBool("IsJumping", false);
    }


}
