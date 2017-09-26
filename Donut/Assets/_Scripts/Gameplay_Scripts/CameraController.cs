using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 m_velocity;

    [SerializeField]
    private GameObject m_player;

    private float m_smoothTimeY;
    private float m_smoothTimeX;

    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        m_smoothTimeX = 0.05f;
        m_smoothTimeY = 0.05f;
    }

    private void Update()
    {
        // Have to update the player object regularly so it doesn't break when we switch characters
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
            float posX = Mathf.SmoothDamp(transform.position.x, m_player.transform.position.x, ref m_velocity.x, m_smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, m_player.transform.position.y, ref m_velocity.y, m_smoothTimeY);

            transform.position = new Vector3(posX, posY + 0.5f , transform.position.z);
    }
}
