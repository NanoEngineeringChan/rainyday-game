using UnityEngine;

public class TrashJuiceController : PlayableCharacter
{
    private TrashJuiceMovement _trashMovement;
    private CharacterStats _trashJuiceStats;
    private HealthBar _trashJuiceHealthBar;

    private new void Awake()
    {
        base.Awake();

        _trashMovement       = GetComponent<TrashJuiceMovement>();
        _trashJuiceStats     = GetComponent<CharacterStats>();
        _trashJuiceHealthBar = GetComponent<HealthBar>();

        transform.position = new Vector3(transform.position.x, transform.position.y, 5f);
    }

    private new void Start ()
	{
        base.Start();
        Initialize();
	}

    public void Update()
    {
        if (_trashJuiceHealthBar != null)
        {
            _trashJuiceHealthBar.UpdateBar(_trashJuiceStats.CurrentHealth, _trashJuiceStats.MaxHealth);
        }
    }

    protected override void Initialize()
    {
        base.Initialize();

        // Initialize Movement Properties
        CharacterName = "Trash Juice";

        _trashMovement.InitializeMovement(5.5f, 0.0f);
        _trashJuiceStats.InitializeHealth(150);
    }
}
