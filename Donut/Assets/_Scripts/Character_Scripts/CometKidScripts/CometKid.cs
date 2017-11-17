using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometKid : PlayableCharacter
{
<<<<<<< HEAD
    public CometKidMovement _cometMovement { get; set; }

=======
    private PlayerMovement _cometMovement;
>>>>>>> 647e47d88aa90f406d0ddb33974f52266c972a0c

    public new void Awake()
    {
        base.Awake();

<<<<<<< HEAD
        _cometMovement = GetComponent<CometKidMovement>();
=======
        _cometMovement = GetComponent<PlayerMovement>();
>>>>>>> 647e47d88aa90f406d0ddb33974f52266c972a0c
    }

    public new void Start()
    {
        base.Start();

        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();

        CharacterName = "Comet Kid";

        _cometMovement.MoveSpeed = 12.0f;
    }
}
