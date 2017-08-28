using UnityEngine;

[System.Serializable]

[RequireComponent (typeof(PlayerMovement))]

public class BlueDonutController : PlayableCharacter
{
    private float m_blueDonutSpeed;
    private float m_blueDonutJump;

    private Animator m_blueDonutAnimator;

    private void Awake()
    {
        m_playerMovement = GetComponent<PlayerMovement>();
        m_blueDonutAnimator = GetComponent<Animator>();
    }


    private void Start()
    {
        base.Start();
        Initialize();
    }

    private void Initialize()
    {
        m_blueDonutSpeed = 10f;
        m_blueDonutJump = 20f;

        m_playerMovement = GetComponent<PlayerMovement>();

        if (m_playerMovement == null)
        {
            Debug.Log("Player movement null in green donut");
        }

        m_playerMovement.InitializePlayerMovement(m_blueDonutSpeed, m_blueDonutJump, m_blueDonutAnimator);
    }
}
