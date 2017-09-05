using UnityEngine;

[System.Serializable]

public class BlueDonutController : PlayableCharacter
{
    private DonutMovement m_donutMovement;

    public new void Awake()
    {
        base.Awake();

        m_donutMovement = GetComponent<DonutMovement>();
    }


    public new void Start()
    {
        base.Start();

        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
        CharacterName = "Donut Dog";
        m_donutMovement.MoveSpeed = 10.0f;
        m_donutMovement.JumpSpeed = 25.0f;
    }
}
