using UnityEngine;

public class TrashJuiceController : PlayableCharacter
{
    private TrashJuiceMovement m_trashMovement;
    private CharacterStats m_trashJuiceStats;

    private new void Awake()
    {
        base.Awake();

        m_trashMovement   = GetComponent<TrashJuiceMovement>();
        m_trashJuiceStats = GetComponent<CharacterStats>();
    }

    private new void Start ()
	{
        base.Start();
        Initialize();

        Debug.Log("Trash Juice Health = " + m_trashJuiceStats.CurrentHealth);
	}

    protected override void Initialize()
    {
        base.Initialize();

        // Initialize Movement Properties
        CharacterName = "Trash Juice";

        m_trashMovement.InitializeMovement(5.5f, 0.0f);
        m_trashJuiceStats.InitializeHealth(150);
    }
}
