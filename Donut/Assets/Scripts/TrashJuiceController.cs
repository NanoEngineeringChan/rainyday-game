using UnityEngine;

public class TrashJuiceController : PlayableCharacter
{
    private float m_trashJuiceSpeed;
    private float m_trashJuiceJumpSpeed;

    private Animator m_trashJuiceAnim;

    private void Awake()
    {
        base.Awake();
        m_trashJuiceAnim = GetComponent<Animator>();
    }

    private void Start ()
	{
        base.Start();
        Initialize();
	}

    private void Initialize()
    {
        m_trashJuiceSpeed = 5f;
        m_trashJuiceJumpSpeed = 0f;

        if (m_playerMovement == null)
        {
            Debug.Log("Player movement null in Trash Juice");
        }

        m_playerMovement.InitializePlayerMovement(m_trashJuiceSpeed, m_trashJuiceJumpSpeed, m_trashJuiceAnim);
    }
}
