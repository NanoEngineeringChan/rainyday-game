using UnityEngine;

[System.Serializable]

public class BlueDonutController : PlayableCharacter
{
    private DonutMovement _donutMovement;

    public new void Awake()
    {
        base.Awake();

        _donutMovement = GetComponent<DonutMovement>();
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
        _donutMovement.MoveSpeed = 10.0f;
        _donutMovement.JumpSpeed = 8.0f;
    }
}
