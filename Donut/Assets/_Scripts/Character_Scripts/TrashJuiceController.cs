using UnityEngine;

public class TrashJuiceController : PlayableCharacter
{
    private TrashJuiceMovement m_trashMovement;
    private CharacterStats m_trashJuiceStats;
    private UIBar m_trashJuiceHealthBar;

    private new void Awake()
    {
        base.Awake();

        m_trashMovement       = GetComponent<TrashJuiceMovement>();
        m_trashJuiceStats     = GetComponent<CharacterStats>();
        m_trashJuiceHealthBar = GetComponent<UIBar>();
    }

    private new void Start ()
	{
        base.Start();
        Initialize();

        Debug.Log("Trash Juice Health = " + m_trashJuiceStats.CurrentHealth);
	}

    public void Update()
    {
        m_trashJuiceHealthBar.UpdateBar(m_trashJuiceStats.CurrentHealth, m_trashJuiceStats.MaxHealth);
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
