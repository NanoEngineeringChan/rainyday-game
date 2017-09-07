using UnityEngine;

public class TrashJuiceController : PlayableCharacter
{
    private TrashJuiceMovement m_trashMovement;

    private new void Awake()
    {
        base.Awake();

        m_trashMovement = GetComponent<TrashJuiceMovement>();
    }

    private new void Start ()
	{
        base.Start();
        Initialize();
	}

    protected override void Initialize()
    {
        base.Initialize();

        // Initialize Movement Properties
        CharacterName = "Trash Juice";
        m_trashMovement.MoveSpeed = 3.5f;
        m_trashMovement.JumpSpeed = 0.0f;
    }
}
