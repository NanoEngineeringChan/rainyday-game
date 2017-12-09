using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometKid : PlayableCharacter
{

    public CometKidMovement _cometMovement { get; set; }



    public new void Awake()
    {
        base.Awake();

        _cometMovement = GetComponent<CometKidMovement>();
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
